from concurrent import futures
import grpc
import sys, os
import time

path_dir = (os.path.abspath(os.path.join(os.path.dirname(__file__), '../..')))
sys.path.append(path_dir)

from config import config
from errors.typeErrors import TypeError

path_dir = (os.path.abspath(os.path.join(os.path.dirname(__file__), '../../grpc_stubs')))
sys.path.append(path_dir)

import dispatcher_pb2_grpc
import filter_pb2_grpc
from dispatcher_pb2 import FilterServer, AddFilterServerResponse
from filter_pb2 import ConnectRequest, IncreaseRequest

class DispatcherService(dispatcher_pb2_grpc.DispatcherServiceServicer):

    def __init__(self):
        self.path = "servers.txt"
        self.filter_servers = []

        self.getServers()

    def getServers(self):
        file = open(self.path)
        self.filter_servers = []
        for address in file:
            print("addrADD: ", address.replace('\n', ''))
            self.filter_servers.append(address.replace('\n', ""))
        file.close()

    def GetFilterServer(self, request, context):
        self.getServers()
        server_address = ""
        start_time = time.time()
        while server_address == "":
            # если серверы не найдены
            if not self.filter_servers:
                return FilterServer(address=server_address, error=TypeError.NotFoundServers.value)

            for server_addr in self.filter_servers:
                print("server_addr: ", server_addr)
                server_address = server_addr
                channel = grpc.insecure_channel(server_addr)
                stub = filter_pb2_grpc.FilterServiceStub(channel)
                try:
                    response = stub.Connect(ConnectRequest(filterPort=0))
                except:
                    # если получили ошибку при подключении к серверу, значит его уже нет
                    # убираем его из списка серверов, подкдюченных к диспетчеру, также убираем его из файла
                    print("Сервер по адресу ", server_addr, " не существует")
                    self.filter_servers.remove(server_addr)
                    file = open(self.path)
                    with open("servers.txt", "w") as file:
                        for address in self.filter_servers:
                            file.write(address + "\n")
                    file.close()
                    server_address = ""
                    if not self.filter_servers:
                        return FilterServer(address=server_address, error=TypeError.NotFoundServers.value)
                    continue
                
                
                if response.error == TypeError.Success.value:
                    stub.IncreaseCountClients(IncreaseRequest())
                    break
                if response.error == TypeError.ServerFull.value:
                    print('Переполнен')
                    server_address=""
                if (time.time() - start_time > config['time_waiting']):
                    return FilterServer(address=server_address, error=TypeError.WaitingTime.value)            
        return FilterServer(address=server_address, error=TypeError.Success.value)

    def AddFilterServer(self, request, context):
        self.filter_servers.append(request.filterServer.address)
        file = open(self.path, 'a')
        file.write(request.filterServer.address + "\n")
        return AddFilterServerResponse()

def serve():
    server = grpc.server(futures.ThreadPoolExecutor(max_workers=10))
    dispatcher_pb2_grpc.add_DispatcherServiceServicer_to_server(DispatcherService(), server)
    server.add_insecure_port(config['dispatcher_address'])
    server.start()
    print("Диспетчер начал работу по адресу: {}".format(config['dispatcher_address']))
    server.wait_for_termination()

if __name__ == "__main__":
    serve()
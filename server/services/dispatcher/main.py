from concurrent import futures
import grpc
import sys, os

path_dir = (os.path.abspath(os.path.join(os.path.dirname(__file__), '../..')))
print(path_dir)
sys.path.append(path_dir)

from config import config

path_dir = (os.path.abspath(os.path.join(os.path.dirname(__file__), '../filter')))
print(path_dir)
sys.path.append(path_dir)

import main as serve_filter

path_dir = (os.path.abspath(os.path.join(os.path.dirname(__file__), '../../grpc_stubs')))
print(path_dir)
sys.path.append(path_dir)

import dispatcher_pb2_grpc
import filter_pb2_grpc
from dispatcher_pb2 import FilterServer, AddFilterServerResponse
from filter_pb2 import ConnectRequest, IncreaseRequest, DecreaseRequest

class DispatcherService(dispatcher_pb2_grpc.DispatcherServiceServicer):

    def __init__(self):
        self.filter_servers = []

    def GetFilterServer(self, request, context):
        server_address = ""

        while server_address == "":
            # если серверы не найдены
            if not self.filter_servers:
                context.set_code(grpc.StatusCode.NOT_FOUND)
                context.set_details("Серверы не найдены!")
                return FilterServer(address=server_address)

            for server_addr in self.filter_servers:
                print("server_addr: ", server_addr)
                server_address = server_addr
                channel = grpc.insecure_channel(server_addr)
                stub = filter_pb2_grpc.FilterServiceStub(channel)
                try:
                    stub.Connect(ConnectRequest(filterPort=0))
                    stub.IncreaseCountClients(IncreaseRequest())
                    break
                except grpc.RpcError as e:
                    #stub.DecreaseCountClients(DecreaseRequest())
                    server_address = ""
        return FilterServer(address=server_address)

    def AddFilterServer(self, request, context):
        self.filter_servers.append(request.filterServer.address)
        return AddFilterServerResponse()

def serve():
    server = grpc.server(futures.ThreadPoolExecutor(max_workers=10))
    dispatcher_pb2_grpc.add_DispatcherServiceServicer_to_server(DispatcherService(), server)
    server.add_insecure_port(config['dispatcher_address'])
    server.start()
    print("dispatcher started at {}".format(config['dispatcher_address']))
    server.wait_for_termination()

if __name__ == "__main__":
    serve()
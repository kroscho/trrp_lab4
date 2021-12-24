from concurrent import futures
import grpc
import sys, os

path_dir = (os.path.abspath(os.path.join(os.path.dirname(__file__), '../..')))
sys.path.append(path_dir)

from config import config

path_dir = (os.path.abspath(os.path.join(os.path.dirname(__file__), '../../grpc_stubs')))
sys.path.append(path_dir)

from dispatcher_pb2 import FilterServer, AddFilterServerRequest
from filter_pb2 import ConnectResponse, TestMessageResponse, IncreaseResponse, DecreaseResponse
import dispatcher_pb2_grpc
import filter_pb2_grpc

from config import config

class FilterService(filter_pb2_grpc.FilterServiceServicer):

    def __init__(self):
        self.count_clients = 0

    # проверка доступности сервера
    def Connect(self, request, context):
        if self.count_clients + 1 > config['max_clients']:
            context.set_code(grpc.StatusCode.OUT_OF_RANGE)
            context.set_details('Сервер заполнен!')
            return ConnectResponse()
        
        return ConnectResponse() 

    def GetTestMessage(self, request, context):
        print("Получено сообщение от клиента: ", request.test)
        result = {'text': "Успешно обработалось фото, ты крут!"}
        return TestMessageResponse(**result)

    def IncreaseCountClients(self, request, context):
        self.count_clients += 1
        return IncreaseResponse()

    def DecreaseCountClients(self, request, context):
        self.count_clients -= 1
        return DecreaseResponse()


def serve():
    server = grpc.server(futures.ThreadPoolExecutor(max_workers=10))
    filter_pb2_grpc.add_FilterServiceServicer_to_server(FilterService(), server)
    
    # автоматический выбор порта
    port = server.add_insecure_port(config['filter_address'])

##############
    channel = grpc.insecure_channel(config['dispatcher_address'])
    stub = dispatcher_pb2_grpc.DispatcherServiceStub(channel)
    host, _ = config['filter_address'].split(':')
    print("host: ", host, "   port: ", port)
    stub.AddFilterServer(AddFilterServerRequest(filterServer = FilterServer(address=f"{host}:{port}")))
    print('Сервер подключился к диспетчеру')
##############

    server.start()
    print("Сервер обработки стартовал на {}".format(config['filter_address'].split(':')[0] + ':' + str(port)))
    server.wait_for_termination()

if __name__ == "__main__":
    serve()
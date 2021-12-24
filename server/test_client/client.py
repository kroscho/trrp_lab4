import time
import grpc
import sys, os

path_dir = (os.path.abspath(os.path.join(os.path.dirname(__file__), '..')))
print(path_dir)
sys.path.append(path_dir)

from services.filter import main as filter_main

path_dir = (os.path.abspath(os.path.join(os.path.dirname(__file__), '../grpc_stubs')))
print(path_dir)
sys.path.append(path_dir)

from dispatcher_pb2 import FilterServerRequest
from filter_pb2 import TestMessage
import dispatcher_pb2_grpc
import filter_pb2_grpc

def client():
    # time.sleep(2)

    # диспетчер серверов
    try:
        channel = grpc.insecure_channel("192.168.0.100:50052")
        dispatcher_stub = dispatcher_pb2_grpc.DispatcherServiceStub(channel)
    except:
        print("Не удается подключиться к диспетчеру.")
    # получаем сервер для работы с изображением
    filter_server = dispatcher_stub.GetFilterServer(FilterServerRequest())
    print("filter_server: ", filter_server)
    if filter_server.address == "":
        filter_main.serve()
        filter_server = dispatcher_stub.GetFilterServer(FilterServerRequest())
    channel = grpc.insecure_channel(filter_server.address)
    filter_stub = filter_pb2_grpc.FilterServiceStub(channel)
    response = filter_stub.GetTestMessage(TestMessage(test="отправил"))
    print(response.text)

if __name__ == "__main__":
    client()
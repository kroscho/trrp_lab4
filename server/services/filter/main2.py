from concurrent import futures
from logging import error
import grpc
import sys, os
import cv2
import numpy as np
import matplotlib.pyplot as plt
#from serviceFilter import FilterImage

path_dir = (os.path.abspath(os.path.join(os.path.dirname(__file__), '../..')))
sys.path.append(path_dir)

from config import config
from errors.typeErrors import TypeError

path_dir = (os.path.abspath(os.path.join(os.path.dirname(__file__), '../../grpc_stubs')))
sys.path.append(path_dir)

from dispatcher_pb2 import FilterServer, AddFilterServerRequest
from filter_pb2 import ConnectResponse, ImageResponse, IncreaseResponse, DecreaseResponse
import dispatcher_pb2_grpc
import filter_pb2_grpc

from config import config

class FilterService(filter_pb2_grpc.FilterServiceServicer):

    def __init__(self):
        self.count_clients = 0

    # проверка доступности сервера
    def Connect(self, request, context):
        print(TypeError.ServerFull.value)
        
        if self.count_clients + 1 > config['max_clients']:
            return ConnectResponse(error=TypeError.ServerFull.value)
   
        return ConnectResponse(error=TypeError.Success.value) 

    def SendImage(self, request, context):
        img_bytes = request.image
        type_filter = request.type
        #imageFilter = FilterImage(img_bytes, type_filter)
        #result_image = imageFilter.applyFilter()

        nparr = np.frombuffer(img_bytes, np.uint8)
        img = cv2.imdecode(nparr, cv2.IMREAD_COLOR)
        img = cv2.cvtColor(img, cv2.COLOR_BGR2HSV) # convert to HSV
        figure_size = 9 # the dimension of the x and y axis of the kernal.
        new_image = cv2.blur(img ,(figure_size, figure_size))
        result_image = cv2.imencode('.jpg', new_image)[1].tobytes()

        result = {'success': True, "filter_image": result_image}
        return ImageResponse(**result)

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

    channel = grpc.insecure_channel(config['dispatcher_address'])
    stub = dispatcher_pb2_grpc.DispatcherServiceStub(channel)
    host, _ = config['filter_address'].split(':')
    print("host: ", host, "   port: ", port)
    stub.AddFilterServer(AddFilterServerRequest(filterServer = FilterServer(address=f"{host}:{port}")))
    print('Сервер подключился к диспетчеру')

    server.start()
    print("Сервер обработки стартовал на {}".format(config['filter_address'].split(':')[0] + ':' + str(port)))
    server.wait_for_termination()

if __name__ == "__main__":
    serve()
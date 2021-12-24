import time
import grpc
import sys, os
import cv2
import numpy as np

path_dir = (os.path.abspath(os.path.join(os.path.dirname(__file__), '..')))
print(path_dir)
sys.path.append(path_dir)

from services.filter import main as filter_main

path_dir = (os.path.abspath(os.path.join(os.path.dirname(__file__), '../grpc_stubs')))
print(path_dir)
sys.path.append(path_dir)

from dispatcher_pb2 import FilterServerRequest
from filter_pb2 import Image
import dispatcher_pb2_grpc
import filter_pb2_grpc

def client():
    # time.sleep(2)

    # диспетчер серверов
    channel = grpc.insecure_channel("192.168.0.100:50052")
    dispatcher_stub = dispatcher_pb2_grpc.DispatcherServiceStub(channel)

    # получаем сервер для работы с изображением
    #try:
    filter_server = dispatcher_stub.GetFilterServer(FilterServerRequest())
    print("filter_server: ", filter_server)
    #except:
    if filter_server.address == "":
        filter_main.serve()
        filter_server = dispatcher_stub.GetFilterServer(FilterServerRequest())
    channel = grpc.insecure_channel(filter_server.address)
    filter_stub = filter_pb2_grpc.FilterServiceStub(channel)
    
    image = cv2.imread('images/1.jpg')
    img_bytes = cv2.imencode('.jpg', image)[1].tobytes()
    response = filter_stub.SendImage(Image(image=img_bytes, type=1))
    print("Изображение успешно обработалось: ", response.success)

    filter_img = response.filter_image
    nparr = np.frombuffer(filter_img, np.uint8)
    filter_img = cv2.imdecode(nparr, cv2.IMREAD_COLOR)
    cv2.imwrite('images/img-2.png', filter_img)


if __name__ == "__main__":
    client()
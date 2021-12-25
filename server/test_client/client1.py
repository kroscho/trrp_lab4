import time
import grpc
import sys, os
import cv2
import numpy as np

path_dir = (os.path.abspath(os.path.join(os.path.dirname(__file__), '..')))
print(path_dir)
sys.path.append(path_dir)

from errors.typeErrors import TypeError
from errors.errors import getMessageError

path_dir = (os.path.abspath(os.path.join(os.path.dirname(__file__), '../grpc_stubs')))
print(path_dir)
sys.path.append(path_dir)

from dispatcher_pb2 import FilterServerRequest
from filter_pb2 import Image, DecreaseRequest
import dispatcher_pb2_grpc
import filter_pb2_grpc

def client():

    # диспетчер серверов
    channel = grpc.insecure_channel("192.168.43.180:50052")
    dispatcher_stub = dispatcher_pb2_grpc.DispatcherServiceStub(channel)

    # получаем сервер для работы с изображением
    try:
        filter_server = dispatcher_stub.GetFilterServer(FilterServerRequest())
        print("filter_server: ", filter_server)
    except:
        print("Не удается подключиться к диспетчеру.")
        return
    
    if filter_server.error != TypeError.Success.value:
        print(getMessageError(filter_server.error))
        return

    channel = grpc.insecure_channel(filter_server.address)
    filter_stub = filter_pb2_grpc.FilterServiceStub(channel)
    print("Подключились к серверу.")
    time.sleep(10)

    image = cv2.imread('1.jpg')
    print(type(image))
    img_bytes = cv2.imencode('.jpg', image)[1].tobytes()
    try:
        response = filter_stub.SendImage(Image(image=img_bytes, type=2))
    except:
        print("На стороне сервера произошел сбой. Повторите попытку.")
        return
    print("Изображение успешно обработалось: ", response.success)

    filter_img = response.filter_image
    nparr = np.frombuffer(filter_img, np.uint8)
    filter_img = cv2.imdecode(nparr, cv2.IMREAD_COLOR)
    cv2.imwrite('images/img-2.png', filter_img)
    filter_stub.DecreaseCountClients(DecreaseRequest())


if __name__ == "__main__":
    client()
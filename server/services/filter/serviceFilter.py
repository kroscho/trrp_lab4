import cv2
import numpy as np
from enum import Enum
     
class TypeFilter(Enum):
    Mean = 1
    Gauss = 2


class FilterImage():
    def __init__(self, imageBytes, typeFilter):
        self.typeFilter = typeFilter
        self.image = self.getImageFromBytes(imageBytes)

    def getImageFromBytes(image_bytes):
        nparr = np.frombuffer(image_bytes, np.uint8)
        img = cv2.imdecode(nparr, cv2.IMREAD_COLOR)
        return img


    def applyFilter(self):
        if self.typeFilter == TypeFilter.Mean:
            result_img = self.meanFilter()
        elif self.typeFilter == TypeFilter.Gauss:
            result_img = self.gaussFilter()
        return result_img

    def meanFilter(self):
        img = cv2.cvtColor(self.image, cv2.COLOR_BGR2HSV) # convert to HSV
        figure_size = 9 # the dimension of the x and y axis of the kernal.
        new_image = cv2.blur(img ,(figure_size, figure_size))
        result_image = cv2.imencode('.jpg', new_image)[1].tobytes()
        return result_image

    def gaussFilter(self):
        pass
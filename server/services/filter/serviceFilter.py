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

    def getImageFromBytes(self, image_bytes):
        nparr = np.frombuffer(image_bytes, np.uint8)
        img = cv2.imdecode(nparr, cv2.IMREAD_COLOR)
        return img


    def applyFilter(self):
        if self.typeFilter == TypeFilter.Mean.value:
            return self.meanFilter()
        elif self.typeFilter == TypeFilter.Gauss.value:
            return self.gaussFilter()
        return self.meanFilter()

    def meanFilter(self):
        figure_size = 9 # the dimension of the x and y axis of the kernal.
        new_image = cv2.blur(self.image ,(figure_size, figure_size))
        result_image = cv2.imencode('.jpg', new_image)[1].tobytes()
        return result_image

    def gaussFilter(self):
        figure_size = 9 # the dimension of the x and y axis of the kernal.
        new_image = cv2.GaussianBlur(self.image, (figure_size, figure_size), cv2.BORDER_DEFAULT)
        cv2.imwrite('img-2.png', new_image)
        result_image = cv2.imencode('.jpg', new_image)[1].tobytes()
        return result_image
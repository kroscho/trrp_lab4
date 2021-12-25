import cv2
import numpy as np
from enum import Enum
     
class TypeFilter(Enum):
    Mean = 1
    Gauss = 2
    Gray = 3


class FilterImage():
    def __init__(self, imageBytes, typeFilter, figureSize):
        self.typeFilter = typeFilter
        self.figureSize = figureSize # the dimension of the x and y axis of the kernal.
        self.image = self.getImageFromBytes(imageBytes)

    def getImageFromBytes(self, image_bytes):
        nparr = np.frombuffer(image_bytes, np.uint8)
        if self.typeFilter == TypeFilter.Gray.value:
            img = cv2.imdecode(nparr, cv2.IMREAD_GRAYSCALE)
        else:
            img = cv2.imdecode(nparr, cv2.IMREAD_COLOR)
        return img

    def applyFilter(self):
        if self.typeFilter == TypeFilter.Mean.value:
            return self.meanFilter()
        elif self.typeFilter == TypeFilter.Gauss.value:
            return self.gaussFilter()
        elif self.typeFilter == TypeFilter.Gray.value:
            return self.grayFilter()
        return self.meanFilter()

    def meanFilter(self):
        new_image = cv2.blur(self.image ,(self.figureSize, self.figureSize))
        result_image = cv2.imencode('.jpg', new_image)[1].tobytes()
        return result_image

    def gaussFilter(self):
        new_image = cv2.GaussianBlur(self.image, (self.figureSize, self.figureSize), cv2.BORDER_DEFAULT)
        cv2.imwrite('img-2.png', new_image)
        result_image = cv2.imencode('.jpg', new_image)[1].tobytes()
        return result_image

    def grayFilter(self):
        #new_image = cv2.cvtColor(self.image, cv2.COLOR_BGR2GRAY)
        thresh = 127
        new_image = cv2.threshold(self.image, self.figureSize, 255, cv2.THRESH_BINARY)[1]
        cv2.imwrite('img-2.png', new_image)
        result_image = cv2.imencode('.jpg', new_image)[1].tobytes()
        return result_image
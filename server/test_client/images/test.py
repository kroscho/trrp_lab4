## пример конвертации изображения в байты и обратно, плюс применение эффекта

import cv2
import numpy as np
import matplotlib.pyplot as plt

image = cv2.imread('1.jpg')
img_str = cv2.imencode('.jpg', image)[1].tobytes()

#print(img_str)

nparr = np.frombuffer(img_str, np.uint8)
img = cv2.imdecode(nparr, cv2.IMREAD_COLOR)
isWritten = cv2.imwrite('image-2.png', img)
img = cv2.cvtColor(image, cv2.COLOR_BGR2HSV) # convert to HSV
figure_size = 9 # the dimension of the x and y axis of the kernal.
new_image = cv2.blur(img ,(figure_size, figure_size))



if isWritten:
	print('Image is successfully saved as file.')


plt.figure(figsize=(11,6))
plt.subplot(121), plt.imshow(cv2.cvtColor(img, cv2.COLOR_HSV2RGB)),plt.title('Original')
plt.xticks([]), plt.yticks([])
plt.subplot(122), plt.imshow(cv2.cvtColor(new_image, cv2.COLOR_HSV2RGB)),plt.title('Mean filter')
plt.xticks([]), plt.yticks([])
plt.show()
## The activity is Application of Deep Learning to Image Segmentation

Deep learning has achieved remarkable success in various computer vision applications. Image semantic segmentation is one of the key problems in the field of computer vision, and it is to detect and localize different objects or specific regions of an image. Looking at the big picture, semantic segmentation is one of the high-level tasks that paves the way toward complete scene understanding. However, it is still a very challenge task for real-time accurate semantic segmentation. Semantic segmentation has the potential to revolutionize many fields such as self-driving cars and mobile robots.

The main objectives of the project are to: 

Discuss the different layers of a neural network 

Develop a web-based application that will allow hospital oncologists to acces their specific databases for their patient data i.e. CT scans, and have a comparison of a segmented image versus the original image, allowing for a more efficient way of diagnosing their patients correctly. 

A neural network is comprise of three main blocks: input, hidden/neuron layer and the output layer. The input layer is where of the inputs to the neural network are put through. The hidden layer is where weights and neurons, which compute the inputs by adding them and through activations functions. The output is where is the cost function is, which calculates the error difference and "trains" the network's weights to optimize. 

Development of the test and requirements is based on which data set that the model will be ran against. In this case, medical imaging, specifically MRI imaging of cancer. The test will be run with the prototyped/ first iteration of the NN and that NN will be modified based on trying to optimize the tesing (forward propagate) time and the training (backward propagate) time. Modifications will be made to the activation functions and the number layers to get a more detailed segmentation, however, not to have too many hidden layers, as that will waste processing power. The objective is to get the most optimzied NN to run the hardware at full load, as to get the minimal amount of testing and training time. 
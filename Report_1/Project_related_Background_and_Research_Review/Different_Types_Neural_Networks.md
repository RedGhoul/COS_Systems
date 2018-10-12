# What are the differnt types of neural networks used in deep-learning theory? 

Generative Adversarial Network 
Convolutional Neural Network 
Recurrent Neural Network 


## What is a Generative Adversarial Network (GAN) ? 

One neural network, called the generator, generates new data instances, while the other, the discriminator, evaluates them for authenticity; i.e. the discriminator decides whether each instance of data it reviews belongs to the actual training dataset or not. The goal of the discriminator, when shown an instance from the real-world, is to recognize it as authentic.

Here are the steps a GAN takes:

•The generator takes in random numbers and returns an image.

•This generated image is fed into the discriminator alongside a stream of images taken from the actual dataset.

•The discriminator takes in both real and fake images and returns probabilities, a number between 0 and 1, with 1 
representing a prediction of authenticity and 0 representing fake.

There is a double feedback loop: 
•The discriminator is in a feedback loop with the ground truth of the images, which is known.
•The generator is in a feedback loop with the discriminator.

![alt text](/Report_1/Project_related_Background_and_Research_Review/picture_of_GAN_loop.PNG) 

## What are convolutional neural networks? 

Convolutional Neural Networks are very similar to ordinary Neural Networks, they are made up of neurons that have learnable weights and biases. Each neuron receives some inputs, performs a dot product and optionally follows it with a non-linearity. The whole network still expresses a single differentiable score function: from the raw image pixels on one end to class scores at the other. And they still have a loss function (e.g. SVM/Softmax) on the last (fully-connected) layer and all the tips/tricks we developed for learning regular Neural Networks still apply. The main difference, however, is the fact that CNNs make the explicit assumption that the inputs are images, which allows us to encode certain properties into the architecture. These then make the forward function more efficient to implement and vastly reduce the amount of parameters in the network.

Convolutional Neural Networks take advantage of the fact that the input consists of images and they constrain the architecture in a more sensible way. In particular, unlike a regular Neural Network, the layers of a ConvNet have neurons arranged in 3 dimensions: width, height, depth. (Note that the word depth here refers to the third dimension of an activation volume, not to the depth of a full Neural Network, which can refer to the total number of layers in a network.)

![alt text](/Report_1/Project_related_Background_and_Research_Review/CNNvisualization.PNG)
 
 - Left: A regular 3-layer Neural Network. Right: A ConvNet arranges its neurons in three dimensions (width, height, depth), as visualized in one of the layers. Every layer of a ConvNet transforms the 3D input volume to a 3D output volume of neuron activations. In this example, the red input layer holds the image, so its width and height would be the dimensions of the image, and the depth would be 3 (Red, Green, Blue channels).

 ## What is a recurrent neural network (RNN)
A recurrent neural network (RNN) is a class of artificial neural network where connections between units form a directed graph along a sequence. This allows it to exhibit dynamic temporal behavior for a time sequence. Unlike feedforward neural networks, RNNs can use their internal state (memory) to process sequences of inputs. This makes them applicable to tasks such as unsegmented, connected handwriting recognition or speech recognition.

![alt text](/Report_1/Project_related_Background_and_Research_Review/RNN_example.PNG)

Recurrent networks are distinguished from feedforward networks by that feedback loop connected to their past decisions, ingesting their own outputs moment after moment as input. It is often said that recurrent networks have memory. Adding memory to neural networks has a purpose: There is information in the sequence itself, and recurrent nets use it to perform tasks that feedforward networks can’t.

That sequential information is preserved in the recurrent network’s hidden state, which manages to span many time steps as it cascades forward to affect the processing of each new example. It is finding correlations between events separated by many moments, and these correlations are called “long-term dependencies”, because an event downstream in time depends upon, and is a function of, one or more events that came before. One way to think about RNNs is this: they are a way to share weights over time.
 
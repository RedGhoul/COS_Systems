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

(insert GAN loop photo here) 

## What are convolutional neural networks? 


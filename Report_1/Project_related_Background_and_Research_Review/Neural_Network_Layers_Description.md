## Input Layer

The input layer is comprised of all of the inputs that will be going into the model, in this case it will be the information matrix that will be comprised of nxm matrix size. ‘n’ (row) defines the number of inputs and ‘m’ (column) defines the number of entries per input into the matrix. 

## Hidden/Neuron Layer 

This layer is comprised of multiple parts. First set of synapses (weights/multipliers), neurons (adders), second set of synapses. The synapses act as weights i.e. multipliers for on both ends of the neurons. The inputs get fed through the synapses, get sent to the neurons, where they will get added together. An example would be if you have a 3x3 input matrix, call it X, that would be multiplied with the first weight set matrix, call it W(1) as shown below with eq 1. Single inputs are not used for this computation as the matrix mathematics more effectively add terms together. From there, z (2) = 𝛿 (2), which is t, will now be passed through the activation function a (2) = f (z (2)). After the matrix, z (2) = 𝛿 (2), is passed through the first activation function, the resultant matrix was passed through the second set of weights, W(2), which became matrix z(3). The matrix z(3) is then passed to the cost function, y-hat = f(z(3)). 


## Output Layer
The output layer would be the result of the cost function. This cost function would be at the end of the neural network. 

## Forward Propagate

The first pass through the neural network, where the input goes through the synapses and neurons and gets to the output of the cost function is known and the forward propagate. Forward propagation is used to get the output and compare it with the real value to get the error. 

## Backward Propagate

To minimize the error, backward propagation is used. This is done through finding the derivate of the error with respect to each weight and then subtracting that value from each weight value. Here, the function to reduce error is represented here: 

![alt text](/Report_1/Project_related_Background_and_Research_Review/equation1.PNG) 

Expanding on the by applying power rule and chain rule to the above equation, the following is obtained:

![alt text](/Report_1/Project_related_Background_and_Research_Review/equation2.PNG)

For the sake of ease, 2 inputs(blue), 3 neurons (green) and one output (yellow) as shown below:

![alt text](/Report_1/Project_related_Background_and_Research_Review/neural_network_derivation_fixed.PNG)


The partial derivative is being taken with respect to the second set of weights, W (2), because the cost function relies directly on those weights and will use them to determine the error value. Y-yhat describes the error by subtracting the output value from the expected value. As with the second set of weights, we also apply the same calculation to the first set of weights as shown below:
 
 ![alt text](/Report_1/Project_related_Background_and_Research_Review/equation3.PNG) 


The final equation for the first set of weights is: 

![alt text](/Report_1/Project_related_Background_and_Research_Review/equation4.PNG) 

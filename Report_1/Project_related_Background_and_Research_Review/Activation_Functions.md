### What is an activation function? 
It is a function that is added to the output end of a neural network 
This is also known as Transfer Function. 
There are multiple types of functions: Linear, Non-Linear, TanH and ReLU

## Linear activation function
From the graph below, the function is a line or linear. Therefore, the output of the functions will not be confined between any range. The equation represented is  f(x) = x with a range of (-∞, ∞). Although this equation is simple enough to implement, it does not help with the complexity or various parameters of real-life applications data that would be input into neural networks

![alt text](/Report_1/Project_related_Background_and_Research_Review/linear function.PNG) 

## Non-linear activation functions 

Non-linear functions are often used because they're able to match data sets that have a trend similar to what is shown below. This is an easier function for a neural network model to generalize and adapt to when given a variety of data and to differentiate between the output. 

![alt text](/Report_1/Project_related_Background_and_Research_Review/Non-linear function.PNG) 

## Sigmoid activation function

The main reason why for using a sigmoid function is because it exists between (0 to 1). Therefore, it is especially used for models there is a need to predict the probability as an output. Since probability of anything exists only between the range of 0 and 1, sigmoid is the a good choice for such applications.The function is differentiable. That means the slope of the sigmoid curve at any two points can be found.
The function is monotonic(function which is either entirely non-increasing or non-decreasing) but function’s derivative is not. 

![alt text](/Report_1/Project_related_Background_and_Research_Review/Sigmoid function.PNG)


## TanH activation function

The TanH activation function is similar to a sigmoid, however, the range of the tanh function is from (-1 to 1)TanH also has a sigmoidal shape (s-shape), as shown below. The advantage is that the negative inputs will be mapped strongly negative and the zero inputs will be mapped near zero in the TanH graph. The function is differentiable
and monotonic while its derivative is not monotonic.

![alt text](/Report_1/Project_related_Background_and_Research_Review/TanH_Function.PNG) 

## ReLU activation function (Rectified Linear Unit)

Currently, ReLU is the most used activation function in most neural network applications, because a large amount of these of neural networks follow the convolutional neural network (CNN) modelling scheme.the ReLU is half rectified (from bottom). f(z) is zero when z is less than zero and f(z) is equal to z when z is above or equal to zero as shown below. 

![alt text](/Report_1/Project_related_Background_and_Research_Review/ReLU function.PNG) 

Range: [0, ∞)

The function and its derivative both are monotonic.

The issue is that all the negative values become zero immediately which decreases the ability of the model to fit or train from the data properly. That means any negative input given to the ReLU activation function turns the value into zero immediately in the graph which in turns affects the resulting graph by not mapping the negative values appropriately.
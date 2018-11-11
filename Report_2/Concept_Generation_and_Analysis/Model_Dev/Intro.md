COS will be using a CNN based on the U-NET architecture. The development of the model had us make three main choices: Hardware selection, ML framework selection, and CNN architecture selection. We decided not use cloud based virtual machines since in the long term it would be very expensive. The ML framework we choose was Google’s Tensor flow (TF) since it has become the standard in both academic use and production use. TF is what powers all the ML features in all of Google’s products. We choose a CNN over other types of ML models since it has been shown to do the best for visual data learning.
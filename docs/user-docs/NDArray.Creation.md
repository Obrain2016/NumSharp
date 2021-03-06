Before we do some fancy numeric stuff or even machine learning we have to clear one thing. 

**How do we generate NDArrays?**

Since NDArray is the key class in SciSharp stack there must be numerous possibilities how to generate this arrays. And yes that’s the case. 

Maybe first of all we should see the dump way – which can be always used but is not too user friendly.  

----
Dump way 

```
// first standard constructor
// you also specify the generic type of the NDArray
var np = new NDArray<double>();

// set 9 elements into this array
np.Data = new double[] {1,2,3,4,5,6,7,8,9};

// shape it to a 3x3 matrix 
np.Shape = new Shape(3,3);
```

Ok looks not too difficult. But also not too userfriendly. 

We create an empty NDArray< double >, fill it with 9 elements and shape it to 3x3 matrix. 

At this point we could shape it also to a 1x9 vector but we shaped it to a 3x3. 

So with this 3x3 shaped NDArray we can do matrix multiplication but with a 1x9 we could not.

Always be careful with your shape and be sure what you want to do with your elements. 

----
Create by enumeration 

```
// at this point we use a numpy class so it looks like numpy function call 
var np = new Numpy<double>();

// we take the Data / elements from an array 
// we do not need to define the shape here
var np1 = np.array(new double[] {1,2,3,4,5,6} );


```
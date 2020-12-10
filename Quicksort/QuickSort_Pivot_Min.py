#!/usr/bin/env python
# coding: utf-8

# In[10]:


import numpy as np
a = np.loadtxt('C:\\Users\\Vasiliki\\Desktop\\coursera algorithms\\algorithms coursera\\Part 1\\week 3\\QuickSort.txt')


# In[11]:


def partition(A,l,r):
    p=A[l]
    i=l+1
    j=l+1
    count_inv=0
    for j in range(i,r+1):       

        
        if A[j]<p:
# create a temporary variable and swap the values
            temp = A[j]
            A[j] = A[i]
            A[i]= temp
            i+=1
    temp=A[l]
    A[l]= A[i-1]
    A[i-1] = temp

    return r-l ,i-1


# In[12]:


def Quicksort(A,l,r):
    count_inv=0
    if r+1-l<=1:
        print("stamataei edw")
        return 0
    else:
        p=A[l]
        count_inv,a=partition(A,l,r)
        count_inv+=Quicksort(A,l,a-1)
        count_inv+=Quicksort(A,a+1,r)
        
    return count_inv
        
    
    


# In[13]:


count=Quicksort(a,0,len(a)-1)


# In[14]:


count


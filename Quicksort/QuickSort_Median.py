#!/usr/bin/env python
# coding: utf-8

# In[32]:


import numpy as np
a = np.loadtxt('C:\\Users\\Vasiliki\\Desktop\\coursera algorithms\\algorithms coursera\\Part 1\\week 3\\QuickSort.txt')


# In[33]:


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


# In[34]:


def Quicksort(A,l,r):
    count_inv=0
    if r+1-l<=1:
        return 0
    else:
        po=pivot_loc(A,l,r)
        A[l],A[po]=A[po],A[l]
        count_inv,a=partition(A,l,r)
        count_inv+=Quicksort(A,l,a-1)
        count_inv+=Quicksort(A,a+1,r)

    return count_inv
        
   


# In[35]:


def pivot_loc(A,l,r):
    x=(r+1-l)%2
    if x==0:
        pos = (r-l)//2
    else:
        pos = (r+1-l)//2
    a=sorted([A[l], A[l+pos], A[r]])[1]
    if a==A[l]:
        return l
    elif a==A[l+pos]:
        return l+pos
    elif a==A[r]:
        return r

        
    


# In[36]:


def pivot_loc(A,l,r):
    x=(r+1-l)%2
    if x==0:
        pos = (r-l)//2
    else:
        pos = (r+1-l)//2   
    
    # (A-B)*(C-A) >= 0
    if ((A[l]) -  (A[pos]))*((A[r])-(A[l])) >= 0:
        return l
    # (B – A)*(C-B) >=0
    elif ((A[pos]) - (A[l])) * ((A[r]) - (A[pos])) >=0:
        return pos
        #B
    else:
        #C
        return r


# In[38]:


count=Quicksort(a,0,len(a)-1)
count


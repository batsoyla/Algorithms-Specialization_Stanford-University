#!/usr/bin/env python
# coding: utf-8

# In[75]:


import random


# In[76]:


def contract(graph, v, w):
    for node in graph[w]:  # merge the nodes from w to v
        if node != v:  # we dont want to add self-loops
            graph[v].append(node)
        graph[node].remove(w)  # delete the edges to the absorbed 
        if node != v:
            graph[node].append(v)
    del graph[w]  # delete the absorbed vertex 'w'
    return graph


# In[77]:


def mincut(graph):
    cuts=[]
    while len(graph) > 2:
        v = random.choice(list(graph))
        w = random.choice(graph[v])
        contract(graph, v, w)
    mincut = len(graph[list(graph.keys())[0]])
    cuts.append(mincut)
    return cuts


# In[114]:


newDict = {}
with open('C:\\Users\\Vasiliki\\Desktop\\coursera algorithms\\algorithms coursera\\week4\\data.txt', 'r') as f:
    for line in f:
        splitLine = line.split()
        list_of_integers = list(map(int, splitLine))
        newDict[int(list_of_integers[0])] = list_of_integers[1:]
b=mincut(newDict)
print(b)


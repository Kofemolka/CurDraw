import sys
import plotly

import plotly.plotly as py
import plotly.graph_objs as go
import plotly.figure_factory as FF

import numpy as np
import pandas as pd

df = pd.read_csv(sys.argv[1])

trace1 = go.Scatter(
                    x=df['millis'], y=df['current'], # Data
                    mode='lines', name='logx' # Additional options
                   )

layout = go.Layout(title='Current draw',
                   plot_bgcolor='rgb(230, 230,230)')

fig = go.Figure(data=[trace1], layout=layout)

# Plot data in the notebook
py.offline.iplot(fig, filename='simple-plot-from-csv')
import sys
import matplotlib.pyplot as plt
import numpy as np

import matplotlib.cbook as cbook

fname = cbook.get_sample_data(sys.argv[1], asfileobj=False)

# test 2; use names
plt.plotfile(fname, (0, 1))
plt.xlabel('Time')
plt.ylabel('Current (mA)')
plt.grid(True)

plt.show()
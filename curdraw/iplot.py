import serial, time, sys
import matplotlib.pyplot as plt

ser = serial.Serial(sys.argv[1], 115200)

plt.ion()
plt.draw()

count = 0
while 1:
    serial_line = ser.readline()
    print serial_line
    splitline = serial_line.split(',')  
    print splitline[1]
    count = count + 1
    plt.plot([count, splitline[1]])
    plt.draw()

    # Loop restarts once the sleep is finished

ser.close() # Only executes once the loop exits
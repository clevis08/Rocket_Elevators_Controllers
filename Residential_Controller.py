def mElevator(id, status, state, motion, position, door, requestUp, requestDown)
for e in c.elevator:
        if e.ID == ID:
            e.status = status
            e.state = state
            e.motion = motion
            e.position = position
            e.up = up
            e.down = requesdowntDown


###########################################################################################


class elevator(object):
    def __init__(self, id):
    self.id = ID
    self.status = "on"
    self.state = "idle"
    self.motion = "idle"
    self.position = 0
    self.door = "closed"
    self.requestUp = []
    self.requestDown = []

###########################################################################################


 #Variable 
 inputnumberController = "0"
 inputnumberFloor = "0"
 inputnumberColumn = "0"
 inputnumberElevator = "0"
 inputnumberElevatorColumns = "0"

 ###########################################################################################

 #INFORMATION
 print("floor:")
 print("..................")
 inputnumberFloor = inout("Enter the number")
 while not inputFloor.isdigit() or int(inputnumberFloor) <= 0:
     inputnumberFloor = input("Number of floor superior >0 \n")
print("\r")
print("column:")
 print("..................")
 inputnumberColumn = input("Enter the number of columns >0 \n")
    while not inputnumberColumn.isdigit() or int(inputnumberElevator) <= 0:
         inputnumberColumn = input("Number of elevator > 0\n")
print("\r")
print("Elevator/colums")
 print("..................")
inputnumberElevatorColumns = input("Number of elevator/column\n")
    while not inputnumberElevatorColumns.isdigit() or int(inputnumberElevatorColumns) <= 0:


###########################################################################################


numberFloor = int(inputnumberFloor)
numberElevator = int(inputnumberElevator)
numberColumn = int(numberColumn)
numberElevatorColumn = int(inputnumberElevatorColumns)


###########################################################################################

#REQUEST
def addRequest(self, numberFloor, requestList):
    if requestList == "up"
        if self.state == "idle":
            self.state = 'up':
        self.requestUp.append(numberFloor)
        self.resquestUp.sort()
        print("add floor" + str(numberFloor) +)
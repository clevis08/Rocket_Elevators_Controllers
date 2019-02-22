class Column:
    def __init__(self, NumberFLOOR, NumberELEVATOR):
        self.numberfloor = NumberFLOOR
        self.numberelevator = NumberELEVATORt
        self.elevatorlist = []

        for i = 0: i < self.numberelevator i+:
    def let(elevator = NEWELEVATOR(i+1,NumberFLOOR)
    self.elevatorlist(Elevator)
    

class Button:
    def __init__(self, DIRECTION, RequestFLOOR):
        self.direction = DIRECTION
        self.requestfloor = RequestFLOOR
        self.activatebutton = False

class InsideButton:
    def __init__(self, FLOOR):
        self.floor = FLOOR
        self.status= "Desactivated"

class ElevatorController:
    def __init__(self, NumberFLOOR, NumberELEVATOR):
        self.numberfloor = NumberFLOOR
        self.numberelevator = NumberELEVATOR
        self.column = column
        self.elevatorlist = []
        self.floorlist = []
        self.elevatorv = elevator
        self.addFloortoList = addFloortoList
        self.move_next 
    
    def RequestElevator(self, NumberFLOOR):
        self.numberfloor = NumberFLOOR
        self.elevator.activateInsideButton(NumberFLOOR)
        self.elevatoor.move_next


    def FindElevator(self, NumberFloor, DIRECTION):
        numberfloor = NumberFloor
        direction = DIRECTION
        DistanceFLOOR = 999
        SelectedELEVATOR = null
        i = 0
        for e in self.elevatorlist:
        DifferenceFloor = abs(NumberFloor - self.column.elevatorlist [i].currentfloor)
        if DifferenceFloor < DistanceFLOOR:
            DistanceFLOOR = DifferenceFloor
            SelectedELEVATOR = self.column.elevatorlist[i]

            else return (SelectedELEVATOR)

class Elevator:
    def __init__(self, NumberELEVATOR, NumberFLOOR):
        self.numberelevator = NumberELEVATOR
        self.numberfloor = NumberFLOOR
        self.direction = 'NONE'
        self.status = 'idle'
        self.floorlist = []
        self.buttonlist = []
        self.currentfloor = currentfloor
        for (i = 0 ; i < self.numberfloor i+):
            self.buttonlist (NEWInsideButton(i))
            self.currentfloor = 1

    def move_next():
        def let(floorlist =self.floorlist):
        def let(numberfloor = #Floorlist.shift()):
        if (self.currentelevator < numberfloor):
            self.moveDOWN(numberfloor)
            self.moveDOWN(numberfloor)

        else if self.currentelevator < numberfloor
            self.moveUP(numberfloor)
        else
            self.opendoor

    def moveDown(numberfloor):
    print 'elevator is going down'
    self.direction = 'down'
    self.status = 'moving'
    #let interval = setInterval(() =>
        self.currentfloor = self.currentfloor + 1
        print(self.currentelevator)
        if (self.currentelevator = numberfloor)
           #Clear Interval(interval)
           print('Arrived at the Floor' + currentfloor)
           self.opendoor()
       #1000 
    
    def moveUp(numberfloor)
    print 'Elevator is going up'
    self.direction = 'up'
    self.status = 'moving'
    #let interval - setInterval(() =>
        self.currentfloor = self.currentfloor + 1
        print(self.currentfloor)
        if (self.currentfloor = numberfloor)
        #clear interval(interval)
        print('Arrived at the floor' + self.currentfloor)
        self.opendoor()

        #1000
        

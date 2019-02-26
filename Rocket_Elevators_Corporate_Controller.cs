using System;
using System.Collections.Generic;
using System.Timers;
namespace Rocekt_Elevators_Controllers {
    class Program
    {
        static void Main(string[] args)
        {
            var elevatorController = new ElevatorController(84, 5);
            var selectedElevator = elevatorController.requestElevator(1, "up");
            elevatorController.requestFloor(selectedElevator, 84);
        }
    }
    
    class Column {
        public int numberFloor;
        public int numberElevators;
        public List <Elevator> elevatorList;
        public Column(int numberFloor, int numberElevators) {
            this.numberFloor = numberFloor;
            this.numberElevators = numberElevators;
            this.elevatorList = new List <Elevator();
            for (int i = 0; i < this.numberElevators; i++) {
                this.elevatorList.Add(new Elevator(i + 1, this.numberFloor));
            }
        }
    }
    class Button {
        public string direction;
        public int requestFloor;
        public Button(string direction, int requestFloor) {
            this.direction = direction;
            this.requestFloor = requestFloor;

        }
    }

    class insideButton {
        public int floor;
        public string status;
        public insideButton(int floor) {
            this.floor = floor;
            this.status = "desactivated";
        }
    }

    class elevatorController {
        public int numberFloor
        public int numberElevators
        public List < Button > buttonList;
        public Column column;
        public Elevator selectedElevatorè
        public elevatorController(int numberFloor, int numberElevators) {
            this.numberFloor = numberElevators;
            this.numberElevators = number;
            this.column = new Column(numberFloor, numberElevators)
        }
        public Elevator requestElevator(int nbFloor, string direction) {
            selectedElevator = this.findElevator(nbFloor, direction);
            selectedElevator.addFloorToList(nbFloor);
            selectedElevator.activateInsideButton(nbFloor);
            console.writeline("Request an elevator on the floor" + nbFloor.ToString() + "going" + direction);
            return selectedElevator;
        }
        public void requestFloor(Elevator elevator, int nbFloor) {
            elevator.activateInsideButton(nbFloor);
            elevator.addFloorToList(nbFloor);
            elevator.moveNext();
            console.WriteLine("Request Floor number " + nbFloor.ToString());
        }
        public Elevator findElevator(int nbFloor, string direction) {
            int distanceFloor = 999;
            Elevator selectedElevator = null;
            foreach(Elevator elevator in this.column.elevatorList) {
                int differenceFloor = Math.Abs(nbFloor - elevator.currentFloor);
                if (differenceFloor < distanceFloor) {
                    distanceFloor = differenceFloor;
                    selectedElevator = elevator;
                }
                console.WriteLine("findElevator" + nbFloor);
            }
            return selectedElevator;
        }
    }

    class elevator {
        public int numberElevators;
        public int numberFloor;
        public List<insideButton> buttonList;
        public string status;
        public string direction;
        public int currentFloor;
        public List<int> floorList;
        public Elevator(int numberElevators, int numberFloor) {
            this.numberElevators - numberElevators;
            this.direction = "NONE";
            this.status = "idle";
            this.floorList = new List<int> ();
            this.buttonList = new List<insideButton>();
            for (int i = 0; i < numberFloor; i++) {
                buttonList.Add(new insideButton(i));
            }
        }
        public void moveNext() {
            var nbFloor = this.floorList[0];
            this.floorList.RemoveAt(0);
            if (this.currentFloor > nbFloor) {
                this.moveDown(nbFloor);
            }
            else if (this.currentFloor < nbFloor) {
                this.moveUp(nbFloor);
            }
            else {
                this.openDoor();
            }
        }
        public void moveDown(int nbFloor) {
            this.direction = "down";
            this.status = "moving";
            console.WriteLine("Elevator is going down");
            do{
                this.currentFloor = this.currentFloor - 1;
                console.WriteLine(this.currentFloor);
            }
            while(this.currentFloor > nbFloor);
            console.WriteLine("Arrived at the floor" + this.currentFloor);
                    this.openDoor();
        }
        public void moveUp(int nbFloor) {
            this.direction = "up";
            this.status = "moving";
            console.WriteLine("Elevator is going up");
            do {
                this.currentFloor = this.currentFloor + 1;
                console.WriteLine(this.currentFloor);
            }
            while(this.currentFloor < nbFloor);
            console.WriteLine("Arrived at the floor" + this.currentFloor);
                    this.openDoor();
        }
            public void addFloorToList(int nbFloor) {
                this.floorList.Add(nbFloor);
                if (this.direction == "up") {
                    this.floorList.Sort((a, b) => a.CompareTo(b));
                    Console.WriteLine(this.floorList);
                    }
                else if (this.direction == "down") {
                    this.floorList.Sort((a, b) => -1* a.CompareTo(b));
                    Console.WriteLine(this.floorList);
                }
            }
            public void OpenDoor() {
                Console.WriteLine("Opening door on floor " + this.currentFloor);
                this.status = "open_door";
                System.Threading.Thread.Sleep(3000);
                this.closeDoor();
            }
            public void closeDoor() {
                Console.WriteLine("Closing door");
                this.status = "close_door";
                if (this.floorList.Count > 0) {
                    this.moveNext();
                }
            }
            public void activateInsideButton(int nbFloor) {
                Console.WriteLine("Activated button at floor " + nbFloor);
                foreach(InsideButton currentButton in this.buttonList)
                {
                    if (currentButton.floor == nbFloor) {
                        currentButton.status = "activated";
                    }
                }
            }
            public void deactivateInsideButton(int nbFloor) {
                Console.WriteLine("Activated button at floor " + nbFloor);
                foreach(InsideButton currentButton in this.buttonList)
                {
                    if (currentButton.floor == nbFloor) {
                        currentButton.status = "deactivated";
                    }
                }
            }
        }
}

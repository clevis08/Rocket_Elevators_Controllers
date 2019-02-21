class Column {
    constructor(nbFloor, nbElevator){
      this.nbFloor = nbFloor;
      this.nbElevator = nbElevator;
      this.elevatorList = [];


      for (let i = 0; i < this.nbElevator; i++) {
             let elevator = new Elevator(i+1,nbFloor)
             this.elevatorList.push(elevator);
        }
    }
}
class Button{
    constructor (direction, requestFloor) {
        this.direction = direction;
        this.requestFloor = requestFloor;
        this.activateButton = false;
    }
}

class InsideButton{
    constructor (floor) {
        this.floor = floor;
        this.status = "desctivated";

    }
}
class ElevatorController {
    constructor(nbFloor, nbElevator) {
      this.nbFloor = nbFloor;
      this.nbElevator = nbElevator;
      this.column = new Column(nbFloor, nbElevator);
      this.buttonList = [new Button()];

    }


    RequestElevator(floorNumber, direction) {
        var selected_elevator = this.FindElevator(floorNumber, direction);
        selected_elevator.addFloorToList(floorNumber);
        selected_elevator.activateInsideButton(floorNumber);
    }


    RequestFloor(elevator, floorNumber) {
        elevator.activateInsideButton(floorNumber);
        elevator.addFloorToList(floorNumber);
        elevator.move_next();

    }
    FindElevator(FloorNumber, direction) {
        var distanceFloor = 999;
        var selected_elevator = null;
        for (var i = 0; i < this.column.elevatorList.length; i++) {
          var differenceFloor = Math.abs(FloorNumber - this.column.elevatorList[i].currentFloor);
            if (differenceFloor < distanceFloor) {
              distanceFloor = differenceFloor;
              selected_elevator =  this.column.elevatorList[i];
            }
       }
       return selected_elevator;
    }
}

class Elevator {
    constructor(elevator_number, nbFloor) {
        this.elevator_number = elevator_number;
        this.direction = "NONE";
        this.status = "idle";
        this.floorList = [];
        this.buttonList = [];
        for (var i = 0; i < nbFloor; i++) {
            this.buttonList.push(new InsideButton(i));
        }
        this.currentFloor = 1;
    }
    move_next(){
        let floorList = this.floorList
        let floorNumber = floorList.shift();
        if (this.currentFloor > floorNumber){
            this.moveDown(floorNumber);
        }
        else if (this.currentFloor < floorNumber){
            this.moveUp(floorNumber);
        }
        else {
            this.OpenDoor();
        }
    }
    moveDown(floorNumber) {
        console.log ("Elevator is going down");
        this.direction = 'down';
        this.status = 'Moving';
        let interval = setInterval(() => {
            this.currentFloor = this.currentFloor - 1
            console.log(this.currentFloor)
            if (this.currentFloor == floorNumber) {
                clearInterval(interval)
                console.log("Arrived at floor " + this.currentFloor)
                this.OpenDoor()
            }
        }, 1000)
    }

    moveUp(floorNumber) {
        console.log ("Elevator is going up");
        this.direction = 'up';
        this.status = 'Moving';
        let interval = setInterval(() => {
            this.currentFloor = this.currentFloor + 1
            console.log(this.currentFloor)
            if (this.currentFloor == floorNumber) {
                clearInterval(interval)
                console.log("Arrived at floor " + this.currentFloor)
                this.OpenDoor()
            }
        }, 1000)
    }
    addFloorToList(floorNumber){
        this.floorList.push(floorNumber);
        if (this.direction == "Up"){
            this.floorList.sort();
            console.log(this.floorList)
        }
        else if (this.direction == "Down"){
         this.floorList.sort().reverse();
           console.log(this.floorList)
        }
    }

    OpenDoor(){
        console.log("Opening door on floor " + this.currentFloor)
        this.status = 'open_door';
        setTimeout(() => {
          this.closeDoor()
        }, 5000);
    }

    closeDoor(){
        console.log("Closing door");
        this.status = 'close_door';
        if (this.floorList.length > 0) {
            this.move_next()
        }
    }
    activateInsideButton(floorNumber) {
        console.log ("Activated button at floor " + floorNumber);
        if  (this.requestFloor == this.floorList){
            this.activate_InsideButton = false;
            }
        if (this.requestFloor < this.floorList){
            this.moveUp();
            }
        else if (this.requestFloor > this.floorList){
            this.moveDown();
            }
    }
    //}
}
const a = new ElevatorController(10,2);

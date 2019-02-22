/////////////////////////////////////////////////////////
/////////////////////////////////////////////////////////
///////////////         WEEK 2            ///////////////
///////////////  RESIDENTIAL JAVASCRIPT   ///////////////
///////////////                           ///////////////
///////////////         JÉRÉMY            ///////////////
///////////////        LEFEBVRE           ///////////////
/////////////////////////////////////////////////////////
/////////////////////////////////////////////////////////
//________________________ZZ____​ZZZ_____Z_Z_____ZZ___ZZ//
//_____________________Z_ZZZ__ZZ​Z__ZZZ_ZZZ_____ZZZ/////// 
//___________________ZZZZZZZZZZZ​ZZZZZZZZZ_____ZZ__Z//////
//___________________ZZZZZZZZZZZ​ZZZZZZZZZZZZZZZ /////////
//__________________ZZZZZZZZZZZZ​Z____ZZZZZZZZZZZZ ///////
//__________________ZZZZZZZZZZZ_​________ZZZZZZZ__Z //////
//________________ZZZZZ_ZZZZZZZ_​__________ZZZZZZ ////////
//_______________ZZZZZZZZZZZZ___​___________ZZZZZZZ //////
//____________ZZZZZZZZZZZZZZZZZ_​____________ZZZZZZZ /////
//____________ZZZZZZ__ZZZZZZZ___​_____________ZZZZZZZ ////
//____________________ZZZZ______​_____________ZZZZZZZ ////
//_________________ZZZZZ________​_____________ZZZZ_ZZ ////
//__________________ZZ__________​_____________ZZZZ__Z ////
//______________________________​_____________ZZZZZ //////
//________________________ZZZZZZ​ZZ__________ZZZZZZ //////
//_____________________ZZZZZZZZZ​ZZZZZZZZZZZZZZZZZZ //////
//_ZZZZ_____________ZZZZZZZZZZZZ​ZZZZZZZZZZZZZZZ_ZZ //////
//____ZZZZZZ______ZZZZZZZZZZZZZZ​ZZZZZZZZZZZZZZ__Z ///////
//__ZZZZZZZZZZZZZZZZZZZZZZZZZ___​_ZZZZZ__ZZ__Z ///////////
//_Z_____ZZ___ZZZZZZZZZZZZ______​__ZZZZ___Z //////////////
//_Z__ZZ__ZZ___ZZZZZZZZZZZ______​ZZZ__Z //////////////////
//__Z__Z_______ZZZZZZZZZ_______Z​ZZ_______________ZZZZZZZZ 
//______ZZ____ZZZZZZZZZ___Z___ZZ​Z____________ZZZZZZZZZZZZZZZ 
//____________ZZZZZZZZZ__ZZZZZZZ​ZZZ________ZZZZZZZZZZZZZZZZZZ 
//___________ZZZZZZZZZ__Z_ZZZZ__​_Z______ZZZZZZZZZZZZZZZZZZZZZZ 
//____________ZZZZZZZZZZ___ZZZZZ​________ZZZZZZZZZZZZZZZZZZZZZZ​Z 
//____________ZZZZZZZZZ___ZZ__Z_​_______ZZZZZZZZZZZZZZZZZZZZZZZ​Z 
//____________ZZZZZZZZZZ__Z___ZZ​______ZZZZZZZZZZZZZZZZZZZZZZZZ​Z 
//____________ZZZZZZZZZZZ_______​_____ZZZZZZZZZZZ_________ZZZZZ​Z 
//____________ZZZZZZZZZZZZ______​____ZZZZZZZZZ____________ZZZZZ​Z 
//____________ZZZZZZZZZZZZZZZ___​___ZZZZZZZZZ_____________ZZZZZ​Z 
//____________ZZZZZZZZZZZZZZZZZ_​_ZZZZZZZZZ___Z___________ZZZZZ 
//_____________Z__ZZZZZZZZZZZZZZ​ZZZZZZZZZZZZZ____________ZZZZZ 
//________________ZZZZZZZZZZZZZZ​ZZZZZZ___________________ZZZZ 
//_________________Z__ZZZZZZZZZZ​ZZZZZZZ__Z______________ZZZZ 
//__________________Z__ZZZZZZZZZ​ZZZ__ZZZZ_______________ZZZZ 
//______________________ZZZ____Z​ZZ______________________ZZZ 
//________________________ZZZ___​_ZZ____________________ZZZZ 
//______________________________​_______________________ZZZ 
//______________________________​______________________ZZZ/ 
//______________________________​______________________ZZZ/
//______________________________​_______________________ZZZZ 
//______________________________​__________________________ZZZZ​____Z 
//______________________________​______________________________​ZZZZZZ 
//______________________________​______________________________​__ZZZZZ 
//______________________________​______________________________​__ZZZ



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
/////////////////////////////////////////////////////////
///////////////ASK FOR AN ELEVATOR///////////////////////
/////////////////////////////////////////////////////////

    RequestElevator(floorNumber, direction) {
        var selected_elevator = this.FindElevator(floorNumber, direction);
        selected_elevator.addFloorToList(floorNumber);
        selected_elevator.activateInsideButton(floorNumber);
    }

/////////////////////////////////////////////////////////
///////////////ASK A FLOOR 1 TO 10///////////////////////
/////////////////////////////////////////////////////////
    RequestFloor(elevator, floorNumber) {
        elevator.activateInsideButton(floorNumber);
        elevator.addFloorToList(floorNumber);
        elevator.move_next();

    }

/////////////////////////////////////////////////////////
////////SEE WHERE IS THE ELEVATOR 1 TO 10 FLOOR//////////
/////////////////////////////////////////////////////////
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

// Scénario \\
 /////1\\\\\\

 //a.column.elevatorList[0].currentFloor = 1;
 //a.column.
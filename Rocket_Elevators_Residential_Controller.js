//SCENARIO #1

class Column {
    constructor(NumberFLOOR, NumberELEVATOR){ // 
        this.NumberFLOOR = NumberFLOOR;
        this.NumberELEVATOR = NumberELEVATOR;
        this.elevatorLIST =[];

        for (let i = 0; i < this.NumberELEVATOR; i++) {
            let elevator = NEW ELEVATOR(i+1,NumberFLOOR)
            this.elevatorLIST.push(elevator);
        }    
    }
}

class Button {
    constructor(DIRECTION, RequestFLOOR) {
        this.DIRECTION = DIRECTION;
        this.RequestFLOOR = RequestFLOOR;
        this.ActivateButton = false;
    }
}

class InsideButton {
    constructor (FLOOR) {
        this.FLOOR = FLOOR;
        this.Status = "Desactivated";
    }
}

class ElevatorController {
    constructor(NumberFLOOR, NumberELEVATOR) {
        this.NumberFLOOR = NumberFLOOR;
        this.NumberELEVATOR = NumberELEVATOR;
        this.Column = new Column(NumberFLOOR, NumberELEVATOR);
        this.button_list = [new Button()];
    }
}

RequestELEVATOR(NumberFLOOR) {
    elevator.activateInsideButton(NumberFLOOR);
    elevator.addFLOORtoList(NumberFLOOR);
    elevator.move_next();
}

FindELEVATOR(NumberFLOOR) {
    var DistanceFLOOR = 999;
    var SelectedELEVATOR = null;
    for (var i = 0; i < this.Column.elevatorList.length; i++) {
        var DifferenceFLOOR = Math.abs(NumberFLOOR - this.Column.elevatorList [i].currentFLOOR);
        if (DifferenceFLOOR < DistanceFLOOR) {
            DistanceFLOOR = DifferenceFLOOR;
            SelectedELEVATOR = this.Column.elevatorList[i];
        }
        return SelectedELEVATOR;
    }
}

class ELEVATOR {
    constructor(NumberELEVATOR, NumberFLOOR) {
        this.NumberELEVATOR - NumberELEVATOR;
        this.direction = "NONE";
        this.status - "idle";
        this.FLOORList = [];
        this.button_list = [];
        for (var i = 0; i < NumberFLOOR; i++) {
            this.button_list.push(new InsideButton(i));
        }
        this.currentFLOOR = 1;
    }
    move_next(){
        let FLOORList = this.FLOORList
        let NumberFLOOR = FLOORList.shift();
        if (this.currentFLOOR > NumberFLOOR){
            this.moveDOWN(NumberFLOOR);
        }
        else if (this.currentFLOOR < NumberFLOOR){
            this.moveUP(NumberFLOOR);
        }
        else {
            this.OpenDOOR();
        }
    }
    moveDOWN(NumberFLOOR) {
        console.log ("ELEVATOR GOING DOWN");
        this.DIRECTION = 'down';
        this.status = 'moving';
        let interval = setInterval(() => {
            this.currentFLOOR = this.currentFLOOR - 1
            console.log(this.currentFLOOR) 
                if (this.currentFLOOR = NumberFLOOR) {
                    clearInterval(interval)
                    console.log("ARRIVED AT THE FLOOR" + this.currentFLOOR)
                    this.OpenDOOR()
                }
            }, 1000)
        }        
    moveUp(NumberFLOOR) {
        console.log ("Elevator is going up");
        this.DIRECTION = 'UP';
        this.status = 'MOVING';
         let interval = setInterval(() => {
            this.currentFLOOR = this.currentFLOOR + 1
            console.log(this.currentFLOOR)
                if (this.currentFLOOR == NumberFLOOR) {
                    clearInterval(interval)
                    console.log("Arrived at floor " + this.currentFLOOR)
                    this.OpenDOOR()
                }
            }, 1000)
        }
        addFLOORtoList(NumberFLOOR){
            this.FLOORList.push(NumberFLOOR);
            if (this.DIRECTION = "UP"){
                this.FLOORList.sort();
                console.log(this.FLOORList)
            }
            else of (this.DIRECTION = "DOWN"){
                this.FLOORList.sort().reverse();
                  console.log(this.FLOORList)
            }
        }
        
        OpenDOOR(){
            console.log("OPEN DOOR AT THE FLOOR" + this.currentFLOOR)
            this.status = 'OpenDOOR';
            setTimeout(() => {
                this.closeDOOR()
            }, 5000);
        }

        closeDOOR(){
            console.log("DOOR CLOSED");
            this.status = 'closeDOOR';
            if (this.FLOORList.length > 0) {
                this.move_next()
            }
        }
        activateInsideButton(NumberELEVATOR) {
            console.log ("ACTIVATED BUTTON AT THE FLOOR" + NumberFLOOR);
            if (this.RequestFLOOR = this.FLOORList) {
                this.activateInsideButton = false;
                }
            if (this.RequestFLOOR < this.FLOORList){
                this.moveUP();
                }
            else if (this.RequestFLOOR > this.FLOORList){
                this.moveDOWN();
                }
        }
}
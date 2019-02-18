class Column {
    constructor(NumberFLOOR, NumberELEVATOR){
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

class ElevatorController {}
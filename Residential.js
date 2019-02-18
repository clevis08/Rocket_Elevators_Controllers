call Column {
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
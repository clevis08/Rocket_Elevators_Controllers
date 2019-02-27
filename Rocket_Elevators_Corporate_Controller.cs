using System;
using System.Collections.Generic;
using System.Linq;
using System.Timers
namespace Rocket_Elevators_Corporate_Controller
{
    public class Elevator
    {
        public string ID{get; set;}
        public string status{get; set;}
        public string direction{get; set;}
        public string motion{get; set;}
        public int position{get; set;}
        public int weight{get; set;}
        public List<int> requestUP{get; set;}
        public List<int> requestDown{get; set;}
        public string door{get; set;}
        public bool dSensor{get; set;}

        public Elevator(string iD)
        { 
            this.ID = iD; 
            this.status = "On";
            this.direction = "Idle";
            this.motion = "Idle";
            this.position = 0;
            this.weight = 0;
            this.requestUP = new List<int>();
            this.requestDown = new List<int>();
            this.door = "Closed";
            this.dSensor = false;
        }
    }

public class Column
{

    public string ID{get; set;}
    public List<Elevator> columnElevator{get; set;}
    public List<int> Serve{get; set;}

    public Column(string id)
    {
        this.ID = id;
        this.columnElevator = new List<Elevator>();
        this.Serve = new List<int>();
    }
}


public class GroundfloorButton
{

    public string ID{get;}
    public int Floor{get;}
    public string direction{get;}
    public bool IsPressed{get; set;}
    public bool Light{get; set;}

    public GroundfloorButton(string id, int floor, string direction)
    {
        this.ID = id;
        this.Floor = floor;
        this.direction = direction;
    }
}


public class floorButton
{
    public string ID{get;}
    public int Floor{get;}
    public Elevator Elevator{get;}
    public bool IsPressed{get; set;}
    public bool Light{get; set;}

    public floorButton(string id, int floor, Elevator elevator)
    {
        this.ID = id;
        this.Floor = floor;
        this.Elevator = elevator;
    }
}

public class Battery
{
    public string Name{get;}
    public List<Elevator> Elevators{get;}
    public List<Column> Columns{get;}
    public List<GroundfloorButton> GroundfloorButtons{get;}
    public List<floorButton> floorButtons{get;}
    public int maxWeight{get; private set;}
    public string inputnumberFloor{get;private set;}
    public string inputnumberColumns{get;private set;}
    public string inputnumberElevators{get; private set;}
    public string inputnumberElevatorsByColumns{get;private set;}
    public int numberFloor{get; private set;}
    public int numberColumns{get; private set;}
    public int numberElevators{get; private set;}
    public int numberElevatorsByColumns{get; private set;}

    public Battery(string name)
    {
        this.Name = name;
        this.Elevators = new List<Elevator>();
        this.Columns = new List<Column>();
        this.GroundfloorButtons = new List<GroundfloorButton>();
        this.floorButtons = new List<floorButton>();
        this.maxWeight = 4500;
    }

    public void Input()
    {
        Console.WriteLine("---------------------------------------");
        Console.WriteLine("ENTER THE INFORMATION TO BUILDING\r");
        Console.WriteLine("---------------------------------------\n");
        int value;


// NUMBER OF FLOOR
        Console.WriteLine("FLOORS:");
        Console.WriteLine("ENTER THE NUMBER OF FLOOR IN THE BUILDING: ");
        inputnumberFloor = Console.ReadLine();
        while (!Int32.TryParse(inputnumberFloor, out value) || Int32.Parse(inputnumberFloor) <= 0)
        {
            Console.WriteLine("NUMBER OF FLOOR ­­> 0 : ");
            inputnumberFloor = Console.ReadLine();
        }


// NUMBER OF COLUMNS
        Console.WriteLine("\r");
        Console.WriteLine("COLUMNS:");
        Console.WriteLine("ENTER THE NUMBER OF COLUMN ");
        inputnumberColumns = Console.ReadLine();
        while (!Int32.TryParse(inputnumberColumns, out value) || Int32.Parse(inputnumberColumns) <= 0)
        {
            Console.WriteLine("NUMBER OF FLOOR ­­> 0 :");
            inputnumberColumns = Console.ReadLine();
        }
// NUMBER OF ELEVATOR
        Console.WriteLine("\r");
        Console.WriteLine("ELEVATORS:");
        Console.WriteLine("ENTER THE NUMBER OF ELEVATOR: ");
        inputnumberElevators = Console.ReadLine();
        while (!Int32.TryParse(inputnumberElevators, out value) || Int32.Parse(inputnumberElevators) <= 0)
        {
            Console.WriteLine("NUMBER OF FLOOR ­­> 0 :");
            inputnumberElevators = Console.ReadLine();
        }
        //Number of elevators by columns
        Console.WriteLine("\r");
        Console.WriteLine("ELEVATORS BY COLUMNS:");
        Console.WriteLine("ENTER THE NUMBER OF ELEVATOR/COLUMNS ");
        inputnumberElevatorsByColumns = Console.ReadLine();
        while (!Int32.TryParse(inputnumberElevatorsByColumns, out value) || Int32.Parse(inputnumberElevatorsByColumns) <= 0)
        {
            Console.WriteLine("NUMBER OF FLOOR ­­> 0 :");
            inputnumberElevatorsByColumns = Console.ReadLine();
        }
        Console.WriteLine("\n");

// DONE
        numberFloor = Int32.Parse(inputnumberFloor);
        numberElevators = Int32.Parse(inputnumberElevators);
        numberColumns = Int32.Parse(inputnumberColumns);
        numberElevatorsByColumns = Int32.Parse(inputnumberElevatorsByColumns);
    }

    public void ShowElevators()
    {
        Console.WriteLine("ELEVATORS");
        int i = 0;
        foreach (Elevator elevator in Elevators)
        {
            if (elevator.requestUP.Any() && elevator.requestDown.Any()){
                Console.WriteLine("ID: " + elevator.ID + ", status: " + elevator.status + ", direction: " + elevator.direction + ", motion: " + elevator.motion + ", Positon: " + elevator.position + ", door: " + elevator.door + ", Requests Up: [" + string.Join(',', elevator.requestUP) + "], Requests Down: [" + string.Join(',', elevator.requestDown) + "]");
            }
            else if (elevator.requestUP.Any() && !elevator.requestDown.Any()){
                Console.WriteLine("ID: " + elevator.ID + ", status: " + elevator.status + ", direction: " + elevator.direction + ", motion: " + elevator.motion + ", Positon: " + elevator.position.ToString() + ", door: " + elevator.door.ToString() + ", Requests Up: [" + string.Join(',', elevator.requestUP) + "], Requests Down: []");
            }
            else if (!elevator.requestUP.Any() && elevator.requestDown.Any()){
                Console.WriteLine("ID: " + elevator.ID + ", status: " + elevator.status + ", direction: " + elevator.direction + ", motion: " + elevator.motion + ", Positon: " + elevator.position.ToString() + ", door: " + elevator.door.ToString() + ", Requests Up: [], Requests Down: [" + string.Join(',', elevator.requestDown) + "]");
            }
            else if (!elevator.requestUP.Any() && !elevator.requestDown.Any()){
                Console.WriteLine("ID: " + elevator.ID + ", status: " + elevator.status + ", direction: " + elevator.direction + ", motion: " + elevator.motion + ", Positon: " + elevator.position.ToString() + ", door: " + elevator.door.ToString() + ", Requests Up: [], Requests Down: []");
            }
            i++;
        }
        Console.WriteLine("\r");
    }

    public void ShowColumns()
    {
        Console.WriteLine("COLUMNS");
        int i = 0;
        int n = 0;
        foreach (Column column in Columns)
        {
            List<string> EleID = new List<string>();
            n = 0;
            foreach (Elevator e in column.columnElevator)
            {
                EleID.Add(e.ID);
                n++;
            }
            Console.WriteLine("ID: " + column.ID + ", Elevators: [" + string.Join(',', EleID) + "]");
            i++;
        }
       Console.WriteLine("\r");
    }
////////////////////////////////////////////////////////////////////////////////////////////////
    public void ShowGroundfloorButtons()
    {
        Console.WriteLine("Ground Floor Buttons:");
        int i = 0;
        foreach (GroundfloorButton GfBtn in GroundfloorButtons)
        {
            Console.WriteLine("ID: " + GfBtn.ID + ", Floor: " + GfBtn.Floor.ToString() + ", direction: " + string.Join(',',GfBtn.direction) + ", IsPressed: " + string.Join(',',GfBtn.IsPressed) + ", Light: " + string.Join(',',GfBtn.Light));
            i++;
        }
    }

////////////////////////////////////////////////////////////////////////////////////////////////
    public void ShowfloorButtons()
    {
        Console.WriteLine("Floor Buttons:");
        int i = 0;
        foreach (floorButton fBtn in floorButtons)
        {
            Console.WriteLine("ID: " + fBtn.ID + ", Floor: " + string.Join(',',fBtn.Floor) + ", Elevator: " + string.Join(',',fBtn.Elevator) + ", IsPressed: " + string.Join(',',fBtn.IsPressed) + ", Light: " + string.Join(',',fBtn.Light));
            i++;
        }
    }

////////////////////////////////////////////////////////////////////////////////////////////////
    public void AddRequest(Elevator elevator, int FloorNumber, string ReqList)
    {
        switch (ReqList)
        {
            case "Up":
                if (elevator.direction == "Idle")
                {
                    elevator.direction = "Up";
                }
                elevator.requestUP.Add(FloorNumber);
                elevator.requestDown.OrderBy(item => item).ToList();
                Console.WriteLine(">>> Added request for floor: " + FloorNumber.ToString() + " to elevator: " + elevator.ID.ToString() + " on Request list Up.");
                Console.WriteLine("\r");
            break;
            case "Down":
                if (elevator.direction == "Idle")
                {
                    elevator.direction = "Down";
                }
                elevator.requestDown.Add(FloorNumber);
                elevator.requestDown.OrderByDescending(item => item).ToList();
                Console.WriteLine(">>> Added request for floor: " + FloorNumber.ToString() + " to elevator: " + elevator.ID.ToString() + " on Request list Down.");
            break;
        }
    }

////////////////////////////////////////////////////////////////////////////////////////////////
    public void weightSensor(Elevator elevator)
    {
    int weight = 200;
    elevator.weight = weight;
    }

////////////////////////////////////////////////////////////////////////////////////////////////
    public int MoveUp(Elevator elevator)
    {
        if (elevator.motion == "Stop")
        {
            Console.WriteLine("> Elevator: " + elevator.ID.ToString() + ", Started engine to go Up");
        }
        elevator.motion = "Up";
        elevator.position +=1;
        return elevator.position;
    }

////////////////////////////////////////////////////////////////////////////////////////////////
    public int MoveDown(Elevator elevator)
    {
       if (elevator.motion == "Stop"){
        Console.WriteLine("> Elevator: " + elevator.ID.ToString() + ", Started engine to go Down");
       }
       elevator.motion = "Down";
       elevator.position -=1;
       return elevator.position;
    }

////////////////////////////////////////////////////////////////////////////////////////////////
    public void doors(Elevator elevator)
    {
        if (elevator.motion == "Stop"){
            elevator.door = "Open";
            Console.WriteLine("\r");
            Console.WriteLine(">>> Elevator: " + elevator.ID.ToString() + ", doors: " + elevator.door.ToString());
        }

        weightSensor(elevator);
        while (elevator.door == "Open"){
            if (elevator.weight >= maxWeight){
                Console.WriteLine(">>> Alert! The elevator Max weight has been reached! Please get out!");
            }
            else if (elevator.dSensor){
                Console.WriteLine(">>> Alert! door sensor detected!");
            }
            else{
                elevator.door = "Closed";
                Console.WriteLine(">>> Elevator: " + elevator.ID.ToString()+ ", doors: " + elevator.door.ToString());
                Console.WriteLine("---------------------------------------\r");
                Console.WriteLine("\r");
            }
        }
    }

////////////////////////////////////////////////////////////////////////////////////////////////
    public void ServesCalls()
    {
        int i = 0;
        foreach (Elevator elevator in Elevators)
        {
            switch (elevator.direction)
            {
                case "Up":
                    if (elevator.requestUP.Any() && elevator.motion != "Stop")
                    {
                        if (elevator.position < elevator.requestUP[0])
                        {
                            if (elevator.motion != "Up")
                            {
                                Console.WriteLine("> Elevator: " + elevator.ID.ToString() + ", Started engine to go Up");
                            }
                            if (MoveUp(elevator) == elevator.requestUP[0])
                            {
                                Console.WriteLine(">> Elevator: " + elevator.ID + ", Has arrived at destination on floor: " + elevator.requestUP[0].ToString());
                                elevator.requestUP.RemoveAt(0);
                                elevator.motion = "Stop";
                                doors(elevator);
                            }
                        }    
                        else if (elevator.position > elevator.requestUP[0])
                        {
                            if (elevator.motion != "Down")
                            {
                                Console.WriteLine("> Elevator: " + elevator.ID + ", Started engine to go Down");
                            }
                            if (MoveDown(elevator) == elevator.requestUP[0])
                            {
                                Console.WriteLine(">> Elevator: " + elevator.ID + ", Has arrived at destination on floor: " + elevator.requestUP[0].ToString());
                                elevator.requestUP.RemoveAt(0);
                                elevator.motion = "Stop"; 
                                doors(elevator); //Open the doors
                            }
                        }
                    }
                    else if (elevator.requestUP.Any() && elevator.motion == "Stop")
                    {
                        if (elevator.door == "Closed"
                        ){
                            if (MoveUp(elevator) == elevator.requestUP[0])
                            {
                                Console.WriteLine(">> Elevator: " + elevator.ID + ", Has arrived at destination on floor: " + elevator.requestUP[0].ToString());
                                elevator.requestUP.RemoveAt(0);
                                elevator.motion = "Stop";
                                doors(elevator);
                            }
                        }
                    }
                    else if (!elevator.requestUP.Any() && elevator.motion == "Stop")
                    {
                        if (elevator.door == "Closed")
                        {
                            if (elevator.requestDown.Any())
                            {
                                elevator.direction = "Down"; //It will be treated in the next iteration of the loop. We want to treat it in the Down section now. 
                            }
                            else if (!elevator.requestDown.Any())
                            {
                                elevator.direction = "Idle";
                                elevator.motion = "Idle";
                                Console.WriteLine(">>>> Elevator: " + elevator.ID + " is now Idle");
                            }
                        }
                    }
                    break;
                case "Down":
                    if (elevator.requestDown.Any() && elevator.motion != "Stop")
                    {
                        if (elevator.position > elevator.requestDown[0])
                        {
                            if (elevator.motion != "Down")
                            {
                                Console.WriteLine("> Elevator: " + elevator.ID + ", Started engine to go Down");
                            }
                            if (MoveDown(elevator) == elevator.requestDown[0])
                            {
                                Console.WriteLine(">> Elevator: " + elevator.ID + ", Has arrived at destination on floor: " + elevator.requestDown[0].ToString());
                                elevator.requestDown.RemoveAt(0);
                                elevator.motion = "Stop";
                                doors(elevator);
                            }
                        }
        
                        else if (elevator.position < elevator.requestDown[0])
                        {
                            if (elevator.motion != "Up")
                            {
                                Console.WriteLine("> Elevator: " + elevator.ID + ", Started engine to go Up");    
                            }
                            if (MoveUp(elevator) == elevator.requestDown[0])
                            {
                                Console.WriteLine(">> Elevator: " + elevator.ID + ", Has arrived at destination on floor: " + elevator.requestDown[0].ToString());
                                elevator.requestDown.RemoveAt(0);
                                elevator.motion = "Stop";
                                doors(elevator);
                            }
                        }
                    
                        else if (elevator.requestDown.Any() && elevator.motion == "Stop")
                        {
                            if (elevator.door == "Closed")
                            {
                                if (MoveDown(elevator) == elevator.requestDown[0])
                                {
                                    Console.WriteLine(">> Elevator: " + elevator.ID + ", Has arrived at destination on floor: " + elevator.requestDown[0].ToString());
                                    elevator.requestDown.RemoveAt(0);
                                    elevator.motion = "Stop";
                                    doors(elevator);
                                }
                            }
                        }
                    }
                    else if (!elevator.requestDown.Any() && elevator.motion == "Stop")
                    {
                        if (elevator.door == "Closed")
                        {
                            if (elevator.requestUP.Any())
                            {
                                elevator.direction = "Up";
                            }
                            else if (!elevator.requestUP.Any())
                            {
                                elevator.direction = "Idle";
                                elevator.motion = "Idle";
                                Console.WriteLine(">>>> Elevator: " + elevator.ID + " is now Idle");
                            }
                        }
                    }
                break;
            }
            i++;
        }
    }

////////////////////////////////////////////////////////////////////////////////////////////////
    private void RequestElevator(int FloorNumber, string direction)
    {
        List<Elevator> AvailableElevators = new List<Elevator>();
        bool OnTheWay_U = false;
        bool OnTheWay_D = false;
        int i = 0;
        int minDif = 9999;
        int minReqs = 9999;
        int eleDif;
        int eleReqs;

        Console.WriteLine("> Outside Panel, Request Detected: Floor: " + FloorNumber.ToString() + ", direction: " + direction);
        foreach (Elevator elevator in Elevators)
        {
            if (elevator.status == "On")
            {
                AvailableElevators.Add(elevator);
            }
        }

        if (AvailableElevators.Count() > 1)
        {
            foreach (Elevator AvailableElevator in AvailableElevators)
            {
                switch (direction)
                {
                    case "Up":
                        if (AvailableElevator.direction == "Up")
                        {
                            if (AvailableElevator.requestUP.Contains(FloorNumber))
                            {
                                Console.WriteLine(">> Outside Panel Floor: " + FloorNumber.ToString() + " direction: " + direction + ", Elevator already in requests list. Request aborted.");
                                Console.WriteLine("\n");
                                return;
                            }
                        }
                        else if (AvailableElevator.direction == "Down")
                        {
                            if (AvailableElevator.requestUP.Contains(FloorNumber))
                            {
                                Console.WriteLine(">> Outside Panel Floor: " + FloorNumber.ToString() + " direction: " + direction + ", Elevator already in requests list. Request aborted.");
                                Console.WriteLine("\n");
                                return;
                            }
                        }
                    break;
                    case "Down":
                        if (AvailableElevator.direction == "Down")
                        {
                            if (AvailableElevator.requestDown.Contains(FloorNumber))
                            {
                                Console.WriteLine(">> Outside Panel Floor: " + FloorNumber.ToString() + " direction: " + direction + ", Elevator already in requests list. Request aborted.");
                                Console.WriteLine("\n");
                                return;
                            }
                        }
                        else if (AvailableElevator.direction == "Up")
                        {
                            if (AvailableElevator.requestDown.Contains(FloorNumber))
                            {
                                Console.WriteLine(">> Outside Panel Floor: " + FloorNumber.ToString() + " direction: " + direction + ", Elevator already in requests list. Request aborted.");
                                Console.WriteLine("\n");
                                return;
                            }
                        }
                    break;
                }
            }
                
////////////////////////////////////////////////////////////////////////////////////////////////
            foreach (Elevator AvailableElevator in AvailableElevators)
            {
                if (AvailableElevator.direction == direction)
                {
                    eleDif = AvailableElevator.position - FloorNumber;
                    switch (direction)
                    {
                        case "Up":
                            if (eleDif < 0)
                            {
                                OnTheWay_U = true;
                            }
                            break;
                        case "Down":
                            if (eleDif > 0)
                            {
                                OnTheWay_D = true;
                            }
                            break;
                    }
                }
            }

            if (OnTheWay_U)
            {
                i = 0;
                foreach (Elevator AvailableElevator in AvailableElevators)
                {
                    if (AvailableElevator.direction == "Down")
                    {
                        AvailableElevators.RemoveAt(i);
                    }
                    i++;
                }
            }
            else if (OnTheWay_D)
            {   
                i = 0;
                foreach (Elevator AvailableElevator in AvailableElevators)
                {
                    if (AvailableElevator.direction == "Up")
                    {
                        AvailableElevators.RemoveAt(i);
                    }
                    i++;
                }
            }

////////////////////////////////////////////////////////////////////////////////////////////////
            foreach (Elevator AvailableElevator in AvailableElevators)
            {
                eleDif = Math.Abs(AvailableElevator.position - FloorNumber);
                if (eleDif <= minDif)
                {
                    minDif = eleDif;
                }
            }
            foreach (Elevator AvailableElevator in AvailableElevators)
            {
                eleDif = Math.Abs(AvailableElevator.position - FloorNumber);
                eleReqs = AvailableElevator.requestUP.Count() + AvailableElevator.requestDown.Count();
                if (eleDif == minDif)
                {
                    if (eleReqs <= minReqs)
                    {
                        minReqs = eleReqs;
                    }
                }
            }

////////////////////////////////////////////////////////////////////////////////////////////////
            foreach (Elevator AvailableElevator in AvailableElevators)
            {
                eleDif = Math.Abs(AvailableElevator.position - FloorNumber);
                eleReqs = AvailableElevator.requestUP.Count() + AvailableElevator.requestDown.Count();
                if (eleDif == minDif && eleReqs == minReqs)
                {
                    switch (direction)
                    {
                        case "Up":
                            Console.WriteLine(">> Request processed, elevator found: " + AvailableElevator.ID);
                            AddRequest(AvailableElevator, FloorNumber, "Up");
                            break;
                        case "Down":
                            Console.WriteLine(">> Request processed, elevator found: " + AvailableElevator.ID);
                            AddRequest(AvailableElevator, FloorNumber, "Down");
                            break;
                    }
                }
            }
        }
        else if (AvailableElevators.Count() == 1)
        {
            switch (direction)
            {
                case "Up":
                    Console.WriteLine(">> Request processed, elevator found: " + AvailableElevators[0].ID);
                    AddRequest(AvailableElevators[0], FloorNumber, "Up");
                    break;
                case "Down":
                    Console.WriteLine(">> Request processed, elevator found: " + AvailableElevators[0].ID);
                    AddRequest(AvailableElevators[0], FloorNumber, "Down");
                    break;
            }
        }
        else if (AvailableElevators.Count() == 0)
        {
            foreach (GroundfloorButton GfBtn in GroundfloorButtons)
            {
                if (GfBtn.Floor == FloorNumber && GfBtn.direction == direction)
                {
                    GfBtn.Light = false;
                    GfBtn.IsPressed = false;
                    Console.WriteLine(">> Request processed: No elevators can receive calls at the moment, sorry.");
                    Console.WriteLine("\n");
                    break;
                }
            }
        }
    }

////////////////////////////////////////////////////////////////////////////////////////////////
    public void RequestFloor(Elevator elevator, int RequestedFloor)
    {
        Console.WriteLine("> Inside Panel, Request Detected: Elevator: " + elevator.ID + ", Floor: " + RequestedFloor.ToString());
        Console.WriteLine(">> ...");
        if (elevator.status == "On")
        {
            var Dif = elevator.position - RequestedFloor;
            switch (elevator.direction)
            {
                case "Up":
                    if (Dif < 0 && elevator.requestUP.Contains(RequestedFloor))
                    {
                        Console.WriteLine(">> Inside Panel Elevator: " + elevator.ID + " Elevator already in requests list. Request aborted.");
                        Console.WriteLine("\n");
                        return;
                    }
                    else 
                    {
                        AddRequest(elevator, RequestedFloor, "Up");
                        return;
                    }
                case "Down":
                    if (Dif > 0 && elevator.requestDown.Contains(RequestedFloor))
                    {
                        Console.WriteLine(">> Inside Panel Elevator: " + elevator.ID + " Elevator already in requests list. Request aborted.");
                        Console.WriteLine("\n");
                        return;
                    }
                    else 
                    {
                        AddRequest(elevator, RequestedFloor, "Down");
                        return;
                    }
                case "Idle":
                    if (Dif < 0)
                    {
                        elevator.direction = "Up";
                        AddRequest(elevator,RequestedFloor,"Up");
                        Console.WriteLine(">> Inside Panel Elevator: " + elevator.ID + " Elevator already in requests list. Request aborted.");
                        Console.WriteLine("\n");
                        return;
                    }
                    else if (Dif > 0)
                    {
                        elevator.direction = "Down";
                        AddRequest(elevator,RequestedFloor,"Down");
                        return;
                    }
                    break;
            }
        }
        else 
        {
            Console.WriteLine(">> Inside Panel Elevator: Your request was denied because the elevator can't receive calls at the moment.");
            Console.WriteLine("\n");
        }
    }

////////////////////////////////////////////////////////////////////////////////////////////////
    public void ListenOutsidePanel()
    {
        int floor;
        string direction;
        foreach (GroundfloorButton GfBtn in GroundfloorButtons)
        {
            if (GfBtn.IsPressed == true)
            {
                GfBtn.Light = true;
                floor = GfBtn.Floor;
                direction = GfBtn.direction;
                GfBtn.IsPressed = false;
                RequestElevator(floor, direction);
            }
        }
    }

////////////////////////////////////////////////////////////////////////////////////////////////
    public void ListenFloorPanel()
    {
        Elevator elevator;
        int floor;
        foreach (floorButton fBtn in floorButtons)
        {
            if (fBtn.IsPressed == true)
            {
                fBtn.Light = true;
                elevator = fBtn.Elevator;
                floor = fBtn.Floor;
                fBtn.IsPressed = false;
                RequestFloor(elevator, floor);
            }
        }
    }

////////////////////////////////////////////////////////////////////////////////////////////////
    public void SystemInit()
    {
        int i = 1;
        int a = 1;
        int n = 1;
        double b = Math.Floor((double)numberFloor/(double)numberColumns);       //To lower value cause no overlap so 16 in this case
        int z = (int)b;
        int tempZ;
        int tempA;

        Console.WriteLine("                    System Initialization                   ");
        Console.WriteLine("---------------------------------------");
////////////////////////////////////////////////////////////////////////////////////////////////
        i = 1;
        while (i <= numberElevators)
        {
            string ID = "ele" + i.ToString();
            Elevator e = new Elevator(ID);
            Elevators.Add(e);
            i++;;
        }
        
////////////////////////////////////////////////////////////////////////////////////////////////
        i = 1;
        while (i <= numberColumns)
        {
            string ID = "col" + i.ToString();
            Column column = new Column(ID);
            Columns.Add(column);
            i++;;
        }
        
////////////////////////////////////////////////////////////////////////////////////////////////
        i = 2;
        while (i <= numberFloor)
        {
            string ID_Up = "GfBtn_Floor" + i.ToString();
            GroundfloorButton btn = new GroundfloorButton(ID_Up, i, "UP");
            GroundfloorButtons.Add(btn);
            i++;;
        }

////////////////////////////////////////////////////////////////////////////////////////////////        
        i = 2;
        while (i <= numberElevators)
        {
            string ID = "iBtn" + i.ToString();
            floorButton iB = new floorButton(ID, i, Elevators[i-1]);
            floorButtons.Add(iB);
            i++;
        }

////////////////////////////////////////////////////////////////////////////////////////////////        
        i = 0;
        foreach (Column column in Columns)
        {
            n = 1;
            while (n <= numberElevatorsByColumns)
            {
                if (Elevators.ElementAtOrDefault(i) != null)
                {
                    column.columnElevator.Add(Elevators[i]);
                    i++;
                    n++;
                }
                else
                {
                    break;
                }
            }
        }

////////////////////////////////////////////////////////////////////////////////////////////////
        i = 1;
        while (i <= numberFloor)
        {
            foreach (Column column in Columns)
            {
                tempZ = a + z;
                column.Serve.Add(a);
                column.Serve.Add(tempZ);
                tempA = tempZ + 1;
                a = tempA;
                i = tempZ;
            }
            i++;
        }
      Console.WriteLine("- LISTS CREATED");
      Console.WriteLine("- ELEVATORS READY");
      Console.WriteLine("> SYSTEM READY");
      Console.WriteLine("---------------------------------------\n");
   }
}

}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Timers;

namespace Rocket_Elevators_Corporate_Controller
{
    class Program
    {
        static void Main(string[] args)
        {
            ElevatorController Sanch = new ElevatorController(85, 4, 5);
            Console.WriteLine("Starting initialisation battery ");
            Console.WriteLine("The number of the column : " + Sanch.numberColumns);
            Console.WriteLine("The name of the battery:  " + Sanch);

            Sanch.battery_1.columnList[1].elevatorList[0].numberFloor = 1;
            Sanch.battery_1.columnList[1].elevatorList[1].numberFloor = 23;
            Sanch.battery_1.columnList[1].elevatorList[2].numberFloor = 33;
            Sanch.battery_1.columnList[1].elevatorList[3].numberFloor = 40;
            Sanch.battery_1.columnList[1].elevatorList[4].numberFloor = 42;


            Sanch.assignElevator(24);
            Sanch.assignElevator(28);


            Console.ReadLine();
        }
    }
// CONTROLLER *REQUEST ELEVATOR/BATTERY/ASSIGN/ 
    class ElevatorController
    {
        public int requestFloor;
        public int numberBFloor;
        public int numberElvbyCol;
        public int numberColumns;
        public Battery battery_1;
        public ElevatorController(int numberBFloor, int numberColumns, int numberElvbyCol)
        {
            this.numberBFloor = numberBFloor;
            this.numberColumns = numberColumns;
            this.battery_1 = new Battery(numberBFloor, numberColumns, numberElvbyCol);
        }


        public void RequestElevator(int numberFloor, int requestnumberFloor)
        {
            Console.WriteLine("SOMEON REQUEST AN ELEVATOR AT THE FLOOR : " + requestnumberFloor);
            var column_1 = battery_1.findColumn(requestnumberFloor);
            var nearElevator = column_1.FindnearElevator(requestnumberFloor);
            column_1.createElevators(numberFloor);
            Console.WriteLine("CallButtonLightOn");
            Console.WriteLine("Returning " + nearElevator.elevatorName + " OF COLUMN NUMBER " + battery_1.numberColumns);

            nearElevator.AddFloorToList(requestnumberFloor);
            nearElevator.MoveNext();
        }

        public void assignElevator(int requestnumberFloor)


        {
            Console.WriteLine("Requested Floor at : " + requestnumberFloor);
            var column_1 = battery_1.findColumn(requestnumberFloor);

            var nearElevator = column_1.FindnearElevator(requestnumberFloor);


            nearElevator.AddFloorToList(requestnumberFloor);
            nearElevator.MoveNext();
        }
    }
//PRIMARY CLASS FOR BATTERY ! LIST COLUMN / mPANEL / FIND COLUMNS / CREATE COLUMNS
    class Battery
    {

        public int numberFloors;
        public int numberColumns;
        public int numberElvbyCol;
        public List<Column> columnList;
        public Battery(int numberFloors, int numberColumns, int numberElvbyCol)
        {
            this.numberFloors = numberFloors;
            this.numberColumns = numberColumns;
            this.numberElvbyCol = numberElvbyCol;
            columnList = new List<Column>();
            this.createColumns();

        }
        //WHERE IS THE COLUMN    
        public void createColumns()
        {
            for (int i = 0; i < this.numberColumns; i++)
            {
                var columns = new Column(numberFloors, numberElvbyCol, "Column " + i);
                this.columnList.Add(columns);
            }

        }

        public int displaymPanel(int requestnumberFloor)
        {

            return requestnumberFloor;
        }

        public Column findColumn(int requestFloor)

        {
            if (requestFloor <= 22)
            {
                return columnList[0];
            }
            else if (requestFloor >= 23 && requestFloor <= 43)
            {
                return columnList[1];
            }
            else if (requestFloor >= 44 && requestFloor <= 64)
            {
                return columnList[2];
            }
            else
            {
                return columnList[3];
            }
        }
    }
    // column
        class Column
    {
        public int numberElevators;
        public int numberFloors;
        public string columnName;
        public int numberFloor;
        public List<Elevator> elevatorList;
        public List<CallButton> callbuttonList;
        public Column(int numberFloors, int numberElevators, string columnName)
        {
            this.numberElevators = numberElevators;
            this.numberFloors = numberFloors;
            this.columnName = columnName;
            callbuttonList = new List<CallButton>();
            elevatorList = new List<Elevator>();
            this.createElevators(numberFloor);
            this.createcallButton();
        }

        public void createElevators(int numberFloor)
        {
            for (int i = 0; i < this.numberElevators; i++)
            {
                var elevators = new Elevator("Elevator" + i, numberFloor);
                this.elevatorList.Add(elevators);
            }
        }


        public void createcallButton()
        {
            for (var i = 0; i < this.numberFloors; i++)
            {
                var callbutton = new CallButton(i, "Down");
                if (i != 0)
                {
                    this.callbuttonList.Add(callbutton);
                }
            }
        }

        public Elevator FindnearElevator(int requestnumberFloor)
        {
            var bDifference = 27;
            var nearElevator = 1;

            for (var i = 0; i < elevatorList.Count; i++)
            {
                var differenceFloor = Math.Abs(
                    requestnumberFloor - elevatorList[i].numberFloor
                );
                if (differenceFloor < bDifference)
                {
                    bDifference = differenceFloor;
                    nearElevator = i;
                }
            }
            return elevatorList[nearElevator];
        }
    }
    //call button
    class CallButton
    {
        public int requestFloor;
        public string direction;
        public bool activateButton;
        public CallButton(int requestFloor, string direction)

        {
            this.requestFloor = requestFloor;
            this.direction = "Down";
            this.activateButton = false;
        }
    }
    //elevator
    class Elevator
    {


        public string elevatorName;
        public int numberFloors;
        public string direction;
        public string status;
        public int numberFloor;
        public List<int> requestfloorList;
        public Elevator(string elevatorName, int numberFloor)
        {
            this.elevatorName = elevatorName;
            this.direction = "STOP";
            this.status = "Idle";
            this.numberFloor = numberFloor;
            requestfloorList = new List<int>();
        }
        public void MoveNext()
        {
            int requestnumberFloor = requestfloorList[0];

            while (requestnumberFloor != 1)
            {
                if (numberFloor == requestnumberFloor)
                {


                    Console.WriteLine("CallButtonLightOff");

                    opencloseDoors();
                    requestnumberFloor = resetRequestFloor();
                }
                else if (requestnumberFloor > numberFloor)
                {
                    moveUP();
                    System.Threading.Thread.Sleep(100);
                    Console.WriteLine(numberFloor);
                }
                else
                {
                    moveDown();
                    System.Threading.Thread.Sleep(100);
                    Console.WriteLine(numberFloor);
                }
            }
            Console.WriteLine("CallButtonLighton");
            ResetElevatorToFirstLobby();
            Console.WriteLine("CallButtonLightOff");
            opencloseDoors();
        }

        public void opencloseDoors()
        {
            Console.WriteLine("Open door");
            System.Threading.Thread.Sleep(1000);
            Console.WriteLine("Closing Door");
            System.Threading.Thread.Sleep(1000);
        }
 
        private int resetRequestFloor()
        {
            requestfloorList.RemoveAt(0);
            int requestnumberFloor = 1;
            if (requestfloorList.Count != 0)
            {
                requestnumberFloor = requestfloorList[0];
            }
            return requestnumberFloor;

        }
        public void ResetElevatorToFirstLobby()

        {
            while (numberFloor != 1)
            {
                moveDown();
                Console.WriteLine(numberFloor);
                if (numberFloor == 1)
                {
                    Console.WriteLine("YOU ARE NOW AT " + numberFloor);
                    
                }
            }
        }
//UP
        public void moveUP()
        {
            numberFloor++;
            Console.WriteLine("MovingUp");
        }
// DOWN
        public void moveDown()
        {
            numberFloor--;
            Console.WriteLine("MovingDown");
        }

        public void AddFloorToList(int requestnumberFloor)
        {
            requestfloorList.Add(requestnumberFloor);
            requestfloorList = requestfloorList.OrderByDescending(x => x).ToList();
        }
    }
}

using System;
using System.Collections.Generic;

namespace Cafe
{
    public class Cafe
    {
        public int Income { get; private set; }

        private Queue<Order> Orders;
        private List<Client> Clients;
        private List<Employee> Employees;

        public Cafe()
        {
            Orders = new Queue<Order>();
            Clients = new List<Client>();
            Employees = new List<Employee>();
        }

        public void ClientEntered(Client client)
        {
            if (client.EnterTheCafe() == false)
            {
                return;
            }
            Clients.Add(client);
        }
        
        public void EmployeeEntered(Employee employee)
        {
            if (employee.EnterTheCafe() == false)
            {
                return;
            }
            Employees.Add(employee);
        }

        public void ClientExited(Client client)
        {
            if (client.LeaveTheCafe() == false)
            {
                return;
            }
            Clients.Add(client);
        }

        public void EmployeeExited(Employee employee)
        {
            if (!Employees.Contains(employee) || !employee.LeaveTheCafe())
            {
                throw new Exception("This employee is busy or doesn't exist\n");
            }
            Employees.Add(employee);
        }

        public void AddOrder(Client client, List<Dish> dishes)
        {
            if (Employees.Count == 0)
            {
                throw new Exception("No free employees:(\n");
            }
            if (!Clients.Contains(client))
            {
                throw new Exception("There is no such client:(\n");
            }
            Employee employee = Employees[0];
            Employees.Remove(Employees[0]);
            Orders.Enqueue(new Order(dishes, client, employee));
        }

        public void CompleteOrder()
        {
            if (Orders.Count == 0)
            {
                throw new Exception("There is no orders:(\n");
            }
            Order order = Orders.Dequeue();
            order.CompleteTheOrder();
            if (order.Id % 4 == 0)
            {
                order.Info.Client.AngryAtAnEmployee(order.Info.Employee);
                Income -= 1000;
            }
            Income += order.TotalCost;
            Employees.Add(order.Info.Employee);
            Console.WriteLine("Order id:{0}", order.Id);
            Console.WriteLine("The {0}\nCompleted the order, the {1}Cost: {2}\n", 
                order.Info.Employee, order.Info.Client, order.TotalCost);
        } 
    }
}

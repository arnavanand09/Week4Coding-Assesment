create database Emp

CREATE TABLE Employee (
    id INT PRIMARY KEY IDENTITY(1,1),
    name VARCHAR(100),
    manager VARCHAR(100),
    employeeType VARCHAR(20) CHECK (employeeType IN ('Contract', 'Payroll')),
    
    contractDate DATE NULL,
    duration INT NULL,
    charges DECIMAL(10,2) NULL,

    joiningDate DATE NULL,
    exp INT NULL,
    basic DECIMAL(10,2) NULL,
    da DECIMAL(10,2) NULL,
    hra DECIMAL(10,2) NULL,
    pf DECIMAL(10,2) NULL,
    netSalary DECIMAL(10,2) NULL
);

INSERT INTO Employee (name, manager, employeeType, contractDate, duration, charges)
VALUES 
('Rahul Kumar', 'Anita Sharma', 'Contract', '2023-01-15', 12, 45000.00),
('Meena Singh', 'Ravi Verma', 'Contract', '2022-09-01', 6, 30000.00),
('Ajay Dev', 'Sunil Mehta', 'Contract', '2024-04-20', 18, 60000.00);

INSERT INTO Employee (name, manager, employeeType, joiningDate, exp, basic, da, hra, pf, netSalary)
VALUES
('Pooja Rani', 'Anita Sharma', 'Payroll', '2012-03-10', 12, 50000.00, 5000.00, 4250.00, 6200.00, 48050.00),
('Nikhil Jain', 'Ravi Verma', 'Payroll', '2016-07-01', 8, 40000.00, 2800.00, 2600.00, 4100.00, 41300.00),
('Sneha Das', 'Sunil Mehta', 'Payroll', '2019-05-15', 6, 35000.00, 1435.00, 1330.00, 1800.00, 35965.00),
('Ravi Kiran', 'Anita Sharma', 'Payroll', '2023-08-01', 2, 30000.00, 570.00, 600.00, 1200.00, 29970.00);


SELECT * FROM Employee WHERE employeeType = 'Contract';


SELECT * FROM Employee WHERE employeeType = 'Payroll';

select * from Employee;

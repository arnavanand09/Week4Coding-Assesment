create database Assignment8;

CREATE TABLE Employee (
    EmployeeID INT PRIMARY KEY,
    Name VARCHAR(100) NOT NULL,
    ExperienceYears INT,
    Salary DECIMAL(10, 2),
    DepartmentName VARCHAR(50)
);

CREATE PROCEDURE InsertUpdateEmployee
    @EmployeeID INT,
    @Name VARCHAR(100),
    @ExperienceYears INT,
    @Salary DECIMAL(10, 2),
    @DepartmentName VARCHAR(50)
AS
BEGIN
    SET NOCOUNT ON;
    IF EXISTS (SELECT 1 FROM Employee WHERE EmployeeID = @EmployeeID)
    BEGIN

        UPDATE Employee
        SET
            Name = @Name,
            ExperienceYears = @ExperienceYears,
            Salary = @Salary,
            DepartmentName = @DepartmentName
        WHERE
            EmployeeID = @EmployeeID;

        PRINT 'Record for EmployeeID ' + CAST(@EmployeeID AS VARCHAR) + ' has been UPDATED.';
    END
    ELSE
    BEGIN
      
        INSERT INTO Employee (EmployeeID, Name, ExperienceYears, Salary, DepartmentName)
        VALUES (@EmployeeID, @Name, @ExperienceYears, @Salary, @DepartmentName);

        PRINT 'New record for EmployeeID ' + CAST(@EmployeeID AS VARCHAR) + ' has been ADDED.';
    END
END;
GO


EXEC InsertUpdateEmployee
    @EmployeeID = 1,
    @Name = 'Alice Smith',
    @ExperienceYears = 5,
    @Salary = 65000.00,
    @DepartmentName = 'HR';

EXEC InsertUpdateEmployee
    @EmployeeID = 1,
    @Name = 'Alice M. Smith', 
    @ExperienceYears = 6,     
    @Salary = 70000.00,       
    @DepartmentName = 'HR';
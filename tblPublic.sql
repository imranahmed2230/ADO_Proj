CREATE DATABASE ProjectMainADO
USE ProjectMainADO
CREATE TABLE tblPublic(Pid INT PRIMARY KEY IDENTITY(101,1), Pname VARCHAR(50) NOT NULL, Pphno BIGINT UNIQUE, Pmail VARCHAR(50)UNIQUE,Pselopt CHAR(20)NOT NULL, Pdescription VARCHAR(1000)NOT NULL)
SELECT *FROM SYS.TABLES
SELECT *FROM tblPublic
INSERT INTO tblPublic(Pname,Pphno,Pmail,Pselopt,Pdescription)VALUES('Imran Ahmed','9551621703','imran00.amsce@gmail.com','Feedback','I have raised a complaint and it has been Cleared successfully-Thank You')
INSERT INTO tblPublic(Pname,Pphno,Pmail,Pselopt,Pdescription)VALUES('Irshad Ahamed','6381950719','ibeingofearth@gmail.com','Complaint','I am having trouble in Claiming my PF amount,Kindly take immeadiate actions')
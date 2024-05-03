CREATE DATABASE CRIME;
USE CRIME;

--CREATING TABLES--
CREATE TABLE CRIME (CrimeID int, inctype varchar(255), incidate date, location varchar(255), descriptionc text, statusc varchar(20), PRIMARY KEY(CrimeID));


CREATE TABLE VICTIM (VicID int, CrimeID int, VicName varchar(255), ContInfo varchar(255), injuries varchar(255), PRIMARY KEY(VicID), 
						FOREIGN KEY (CrimeID) REFERENCES CRIME(CrimeID));
ALTER TABLE VICTIM ADD age int; 

CREATE TABLE SUSPECT (SusID int, CrimeID int, SusName varchar(255), SusDesc text, CrimHist text, PRIMARY KEY(SusID), FOREIGN KEY (CrimeID) REFERENCES CRIME (CrimeID));
ALTER TABLE SUSPECT ADD age int;


--ADDING VALUES--
INSERT INTO CRIME (CrimeID, inctype, incidate, location, descriptionc, statusc) VALUES 
(1, 'Robbery', '2023-09-15', '123 Main St, Cityville', 'Armed robbery at a convenience store', 'Open'),
(2, 'Homicide', '2023-09-20', '456 Elm St, Townsville', 'Investigation into a murder case', ' Under Investigation'),
(3, 'Theft', '2023-09-10', '789 Oak St, Villagetown', 'Shoplifting incident at a mall', 'Closed');
SELECT * FROM CRIME;

INSERT INTO VICTIM (VicID, CrimeID, VicName, ContInfo, Injuries, age) VALUES
(1, 1, 'John Doe','johndoe@example.com', 'Minor injuries', 43),
(2, 2, 'Jane Smith', 'janesmith@example.com', 'Deceased', 20),
(3, 3, 'Alice Johnson', 'alicejohnson@example.com', 'None', 32);
SELECT * FROM VICTIM;

INSERT INTO SUSPECT (SusID, CrimeID, SusName, SusDesc, CrimHist, age) VALUES
(1, 1, 'Robber 1', 'Armed and masked robber', 'Previous robbery conviction', 34),
(2, 2, 'Unknown', 'Investigation ongoing', NULL, 43),
(3, 3, 'Suspect 1', 'Shoplifting suspect', 'Prior shoplifting arrests', 37);
SELECT * FROM SUSPECT;



--SOLVING QUERIES--

--1.Select all open incidents--
SELECT * FROM CRIME WHERE statusc = 'Open';

--2.Find the total number of incidents--
SELECT COUNT(inctype) AS Total_incidents FROM CRIME;

--3.List all unique incident types--
SELECT DISTINCT inctype AS IncidentTypes FROM CRIME;

--4.Retrieve incidents that occurred between '2023-09-01' and '2023-09-10'--
SELECT * FROM CRIME WHERE	incidate BETWEEN '2023-09-01' AND '2023-09-10';

--5.List persons involved in incidents in descending order of age--
SELECT VicName AS NamePerson, age FROM VICTIM UNION ALL SELECT SusName, age FROM SUSPECT ORDER BY age DESC;

--6.Find the average age of persons involved in incidents.--
SELECT AVG(age) AS AvgAGE FROM VICTIM UNION ALL SELECT AVG(age) FROM SUSPECT;

--7. List incident types and their counts, only for open cases.--
SELECT inctype, COUNT(*) AS CountOfIncident FROM CRIME WHERE statusc = 'Open' GROUP BY inctype ORDER BY CountOfIncident DESC;


--8.Find persons with names containing 'Doe'--
SELECT * FROM VICTIM WHERE VicName LIKE '%Doe%';

--9. Retrieve the names of persons involved in open cases and closed cases--
SELECT VicName FROM VICTIM JOIN CRIME ON VICTIM.CrimeID = CRIME.CrimeID WHERE CRIME.statusc IN ('Open', 'Closed')
UNION
SELECT SusName FROM SUSPECT JOIN CRIME ON SUSPECT.CrimeID = CRIME.CrimeID WHERE CRIME.statusc IN ('Open', 'Closed');

--10. List incident types where there are persons aged 30 or 40 involved.--
SELECT inctype FROM CRIME where CrimeID in (Select CrimeID from VICTIM WHERE age IN (20,43)
UNION
SELECT CrimeID from SUSPECT WHERE age IN (20,43));

--11.  Find persons involved in incidents of the same type as 'Robbery'.--
SELECT SUSPECT.SusName as PName, SUSPECT.age FROM SUSPECT INNER JOIN CRIME on SUSPECT.CrimeID = CRIME.CrimeID where CRIME.inctype = 'Robbery' Order BY PName;

--12.. List incident types with more than one open case--
INSERT INTO CRIME VALUES (4, 'Robbery', '2023-09-10', '987 Big Street, Bigsville', 'Shoplifting Incident', 'Open');

SELECT CRIME.inctype from CRIME where CRIME.statusc = 'Open' Group BY CRIME.inctype HAVING COUNT(*)>1;

--13. List all incidents with suspects whose names also appear as victims in other incidents.--

INSERT INTO SUSPECT VALUES (4,4, 'Jane Smith', 'None', 'None', 23); 
SELECT CRIME.CrimeID, CRIME.inctype, CRIME.incidate, CRIME.inclocation FROM CRIME 
Inner Join SUSPECT ON CRIME.CrimeID = SUSPECT.CrimeID 
Inner Join VICTIM. ON SUSPECT.SusName = VICTIM.VicName
Where CRIME.CrimeID <> VICTIM.CrimeID;

--14.  Retrieve all incidents along with victim and suspect details.--
Select CRIME.CrimeID, CRIME.inctype, CRIME.inciDate, CRIME.inclocation, CRIME.descriptionC, CRIME.statusc, VICTIM.VicID, VICTIM.VicName as VictimName, VICTIM.age, 
VICTIM.ContInfo, VICTIM.Injuries, SUSPECT.age, SUSPECT.SusName as SuspectName, SUSPECT.age, SUSPECT.SusDesc, SUSPECT.CrimHist FROM CRIME 
LEFT JOIN SUSPECT ON CRIME.CrimeID = SUSPECT.CrimeID
LEFT JOIN VICTIM on CRIME.CrimeID = VICTIM.CrimeID
Order By CRIME.CrimeID;


--15. . Find incidents where the suspect is older than any victim.-
Select CRIME.CrimeID, CRIME.inctype, CRIME.inciDate, CRIME.inclocation from CRIME 
Inner join SUSPECT on CRIME.CrimeID = SUSPECT.CrimeID
Inner join VICTIM on CRIME.CrimeID = VICTIM.CrimeID
Where SUSPECT.age > ALL (SELECT VICTIM.age from VICTIM where VICTIM.CrimeID = CRIME.CrimeID) 
GROUP by CRIME.CrimeID, CRIME.inctype, CRIME.inciDate, CRIME.inclocation;

--16.  Find suspects involved in multiple incidents:--
SELECT SUSPECT.SusName as SUSPECTNAME, SUSPECT.age, COUNT(*) AS IncidentCount FROM SUSPECT
Inner join CRIME on SUSPECT.CrimeID = SUSPECT.CrimeID
GROUP BY SUSPECT.SusID, SUSPECT.SusName, SUSPECT.age
HAVING COUNT(*) > 1;

--17. List incidents with no suspects involved.-- 
SELECT CRIME.CrimeID, CRIME.inctype, CRIME.inciDate, CRIME.inclocation from CRIME 
left join SUSPECT on CRIME.CrimeID = SUSPECT.CrimeID
Where SUSPECT.SusID is NULL;

--18--


--19--
SELECT CRIME.CrimeIF, CRIME. inctype

							

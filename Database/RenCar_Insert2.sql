-------- Insert -----------------



--------------Pendding -----


--Insert data into Clinet table


Insert into Clinet values
('Ali','ali88@gmail.com','1234',0555432671 ,'Qassim')
Insert into Clinet values
('Ahmad','Ahmad87@gmail.com','1234',0508768234 ,'Makkah' )
Insert into Clinet values
('Saleh','Saleh95@gmail.com','1234',0558724561 ,'Makkah')
Insert into Clinet values
('Sara','Sara32@gmail.com','1234',0500871234 ,'Riyadh')
Insert into Clinet values
('Naif','Naif67@gmail.com','1234',0502356182 , 'Qassim')
Insert into Clinet values
('Omar','Omar612@gmail.com','1234',0561380271 ,'Riyadh')
Insert into Clinet values
('Lama','Lama76@gmail.com','1234',0561839282 , 'Qassim')
Insert into Clinet values
('Mohammd','Mohammd01@gmail.com','1234',0558325673 ,'Qassim')
Insert into Clinet values
('Nora','Nora43@gmail.com','1234',0558267182 ,'Makkah')
Insert into Clinet values
('Lana','Lana51@gmail.com','1234',0555572771 ,'Riyadh')

select *
from Clinet

---------------------

------

insert into Car values('BMW','1 Series','Large',2013,'red',200,'Coupe')
insert into Car values('Audi','124 Spider' ,'Small',2005,'blue',300,'Convertible')
insert into Car values('GMC', '1500 Club Coupe' ,'Family',2020,'red',400,'Wagon')
insert into Car values('BMW','1 Series','118d', 2014,'White',200,'Sport')
insert into Car values('BMW','1 Series','116d', 2019,'White',350 ,'Pickup')
insert into Car values('BMW','1 Series','116i', 2020,'White',500 ,'Convertible')
insert into Car values('BMW','X7','xDrive40i', 2022,'Black',500 ,'Family')
insert into Car values('BMW','X1','sDrive20i', 2022,'Brown',500 ,'Extra large')
insert into Car values('Audi','Q4','e-tron', 2022,'Blue',500 ,'Wagon')


select *
from Car


--------

INSERT INTO LOCATION VALUES ('Qassim',NULL)
INSERT INTO LOCATION VALUES ('Makkah',NULL )
INSERT INTO LOCATION VALUES ('Riyadh',NULL )


select *
from LOCATION

-------



--Insert data into Inventory table
Insert into Inventory values (1,1, 0,'2021-12-22' )
Insert into Inventory values (2,2,0,'2021-12-25' ) 
Insert into Inventory values (3,2, 1,NULL )
Insert into Inventory values (4,3, 1,NULL)
Insert into Inventory values (5,1, 0,'2021-11-30' )
Insert into Inventory values (9,2, 1,NULL )
Insert into Inventory values (8,3, 1,NULL )
Insert into Inventory values (7,1,0,'2021-12-30' ) 

select *
from Inventory


-----


----Payment--------------------------------

insert into Payment values(2165226691827620,'2024-08-01','Amani Nagy','mada','Alrajhi bank',1)
insert into Payment values(2155226691827620,'2021-09-01','Amani Alshami','master card','Alinma bank',10)
insert into Payment values(2165226693825620,'2025-10-01','Thekra Alsuhaibani','visa','Alinma bank',9)
insert into Payment values(2165228891827620,'2022-11-01','Ahamd Ali','master card','Alrajhi bank',8)
insert into Payment values(2165222291827620,'2021-12-01','Mohamed Nasir','visa','Alrajhi bank',3)
insert into Payment values(2165226609827620,'2019-06-01','Khulood Ibrahim','visa','Alinma bank',4)
insert into Payment values(2165226618827620,'2025-04-01','Asma Ali','visa','Alinma bank',5)
insert into Payment values(2165226891827620,'2026-08-01','Nasir Ahmad','master card','Alrajhi bank',6)
insert into Payment values(2165826691827620,'2025-06-01','Omar Hamuda','visa','Alahli bank',9)
insert into Payment values(2165206691807620,'2024-05-01','Alaa ALosalli','master card','Alrajhi bank',6)
insert into Payment values(2165226691820920,'2027-04-01','Bader Ali','master card','Alrajhi bank',2)
insert into Payment values(2165226691827999,'2024-03-01','Khaled Ahmad','visa','Alrajhi bank',7)
insert into Payment values(2165226691827987,'2029-08-01','Noura Ahmad','master card','Alinma bank',1)
insert into Payment values(2165226691827623,'2021-08-01','Muhamed Ibrahim','mada','Alinma bank',10)
insert into Payment values(2165226691827612,'2029-08-01','Amina Ibrahim','mada','Alahli bank',8)

select *
from Payment


-------------------Orders---------------------

INSERT INTO orders VALUES ('Done',1,'2020-05-06','2020-05-22',Getdate(),1 ,'Makkah' ,1,5)
INSERT INTO orders VALUES ('Done',2,'2020-03-10','2020-03-22',Getdate(),2,'Qassim',5,2)
INSERT INTO orders VALUES ('Done',3,'2021-05-01','2021-05-03',Getdate(),3 ,'Riyadh',3,1)
INSERT INTO orders VALUES ('Done',4,'2021-06-11','2021-06-22',Getdate() ,1,'Riyadh',6,2)
INSERT INTO orders VALUES ('Done',5,'2021-07-01','2021-07-25',Getdate() ,2,'Qassim' ,2,4)

select *
from Orders


--Insert data into History table
Insert into History values ('2020-05-06','2020-05-22',2,500)
Insert into History values ('2020-03-10','2020-03-22',3,300)
Insert into History values ('2021-05-01','2021-12-30',1,100)
Insert into History values ('2021-06-11','2021-07-25',5,350)
Insert into History values ('2021-07-01','2021-03-04',6,700)

select *
from History

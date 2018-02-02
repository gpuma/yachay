insert into Students values('Melinda Lucía', 'Puente del Monte')
insert into Students values('James', 'Byrne')
insert into Students values('Gustavo', 'Beltrán Linares')
insert into Students values('Geoff', 'Sachs')
insert into Students values('Vito', 'Corleone')

insert into Units values('Web Development', 'II', 0.3, 0.3, 0.4)
insert into Units values('Introduction to Programming', 'I', 0.2, 0.2, 0.6)

select * from Units
select * from Students
select * from Enrollments


insert into Enrollments values(2,1,NULL,NULL,NULL)
insert into Enrollments values(3,1,NULL,NULL,NULL)
insert into Enrollments values(4,1,NULL,NULL,NULL)
insert into Enrollments values(6,1,20,20,20)

select * from Students

update Enrollments
set Grade3 = ABS(CHECKSUM(NewId())) % 20

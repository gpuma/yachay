use yachay

insert into Students values('Melinda Lucía', 'Puente del Monte')
insert into Students values('James', 'Byrne')
insert into Students values('Gustavo', 'Beltrán Linares')
insert into Students values('Geoff', 'Sachs')
insert into Students values('Vito', 'Corleone')

insert into Units values('Web Development', 'II', 0.3, 0.3, 0.4)
insert into Units values('Introduction to Programming', 'I', 0.2, 0.2, 0.6)
insert into Units values('Natural Language Processing', 'IX', 0.4, 0.4, 0.2)
insert into Units values('Advanced Game Design', 'VI', 0.1, 0.1, 0.8)

insert into Enrollments values(2,1,10,20,5)
insert into Enrollments values(3,1,17,19,20)
insert into Enrollments values(4,1,20,13,7)
insert into Enrollments values(6,1,20,20,20)

/*
select * from Units
select * from Students
select * from Enrollments

delete from Units
where unitid > 4

delete from Students
where studentid > 6

update Enrollments
set Grade3 = ABS(CHECKSUM(NewId())) % 20
*/
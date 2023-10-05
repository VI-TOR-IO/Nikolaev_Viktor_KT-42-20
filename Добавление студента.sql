insert into cd_group (c_group_name)
Select 'KT-41-20';

insert into cd_group (c_group_name)
Select 'KT-42-20';

insert into cd_student(c_student_firstname, c_student_lastname, c_student_middlename, f_group_id)
Select 'Ivan','Ivanov','Ivanovich', 1;

insert into cd_student(c_student_firstname, c_student_lastname, c_student_middlename, f_group_id)
Select 'Viktor','Nikolaev','Robertovich', 2;
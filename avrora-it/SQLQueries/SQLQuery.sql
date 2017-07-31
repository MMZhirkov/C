--все образцы и испытания по ним (поля для вывода ORDNO, USRNAME,TESTCODE,TESTNAME)
SELECT *
	FROM ORDERS
 JOIN ORDTASK ON ORDERS.ORDNO = ORDTASK.ORDNO
 
 --все образцы, на которые назначено испытание с кодом (TESTCODE) равным 123 (поле для вывода ORDNO)
SELECT ORDERS.ORDNO
	FROM ORDERS
 JOIN ORDTASK ON ORDERS.ORDNO = ORDTASK.ORDNO
 WHERE TESTCODE = 123
 
 --всех пользователей, которые зарегистрировали образцы, на которые назначено испытание с названием начинающимся с 'Измерения р' (поле для вывода USRNAME).
SELECT ORDERS.USRNAME
	FROM ORDERS
 JOIN ORDTASK ON ORDERS.ORDNO = ORDTASK.ORDNO
 WHERE TESTNAME LIKE 'Измерения р%'
--��� ������� � ��������� �� ��� (���� ��� ������ ORDNO, USRNAME,TESTCODE,TESTNAME)
SELECT *
	FROM ORDERS
 JOIN ORDTASK ON ORDERS.ORDNO = ORDTASK.ORDNO
 
 --��� �������, �� ������� ��������� ��������� � ����� (TESTCODE) ������ 123 (���� ��� ������ ORDNO)
SELECT ORDERS.ORDNO
	FROM ORDERS
 JOIN ORDTASK ON ORDERS.ORDNO = ORDTASK.ORDNO
 WHERE TESTCODE = 123
 
 --���� �������������, ������� ���������������� �������, �� ������� ��������� ��������� � ��������� ������������ � '��������� �' (���� ��� ������ USRNAME).
SELECT ORDERS.USRNAME
	FROM ORDERS
 JOIN ORDTASK ON ORDERS.ORDNO = ORDTASK.ORDNO
 WHERE TESTNAME LIKE '��������� �%'
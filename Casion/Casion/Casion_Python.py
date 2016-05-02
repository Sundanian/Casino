import sqlite3 as lite
import sys


con = None

try:
    con = lite.connect('test.db')
    
    cur = con.cursor()    

    cur.execute("CREATE TABLE if not exists Player(Id INTEGER PRIMARY KEY, Name TEXT, Money int)")
    #cur.execute("INSERT INTO Player VALUES(NULL, 'Morten', 500)")
    
    #with con:
    #    cur.execute("Select * from Player")
    #    rows=cur.fetchall()
    #    for row in rows:
    #        print(row)   
             
except lite.Error, e:
    
    print "Error %s:" % e.args[0]
    sys.exit(1)
    
finally:
    if con:
        con.close()







#import sqlite3 as lite
#import sys

#con = lite.connect('test.db')
#cur = con.cursor()


#cur.execute("CREATE TABLE if not exists Player(Id INTEGER PRIMARY KEY, Name TEXT, Money int)")
#cur.execute("INSERT INTO Player VALUES(NULL, 'Morten', 500)")
#con.commit()

#with con:
#    cur.execute("Select * from Player")
#    rows=cur.fetchall()
#    for row in rows:
#        print(row)
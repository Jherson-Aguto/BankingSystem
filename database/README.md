# Database Setup

Execute the scripts in order:

1. 001_CREATE_SCHEMA.sql
2. 002_CREATE_USER_DETAILS.sql
3. 003_CREATE_ACCOUNT_DETAILS.sql
4. 004_CREATE_AUDIT_DETAILS.sql
5. ...

After the schema is created, run the seed scripts if needed.


NOTE: replace ROLLBACK at the end of sql statements with COMMIT
        if you want to run and save it into the database
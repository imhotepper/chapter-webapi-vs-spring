--CREATE DATABASE todos_java;
 SELECT 'CREATE DATABASE todos_java'
 WHERE NOT EXISTS (SELECT FROM pg_database WHERE datname = 'todos_java'
GRANT ALL PRIVILEGES ON DATABASE todos_java TO postgres;
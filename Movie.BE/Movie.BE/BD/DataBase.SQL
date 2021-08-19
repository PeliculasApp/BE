-- Generado por Oracle SQL Developer Data Modeler 19.4.0.350.1424
--   en:        2021-08-19 01:26:56 CDT
--   sitio:      SQL Server 2012
--   tipo:      SQL Server 2012



CREATE TABLE Actor 
    (
     Id INTEGER NOT NULL , 
     Name VARCHAR (50) NOT NULL , 
     Background VARCHAR (50) NOT NULL 
    )
GO

ALTER TABLE Actor ADD CONSTRAINT actor_PK PRIMARY KEY CLUSTERED (Id)
     WITH (
     ALLOW_PAGE_LOCKS = ON , 
     ALLOW_ROW_LOCKS = ON )
GO

CREATE TABLE Genre 
    (
     Id INTEGER NOT NULL , 
     Name VARCHAR (15) NOT NULL 
    )
GO

ALTER TABLE Genre ADD CONSTRAINT Genre_PK PRIMARY KEY CLUSTERED (Id)
     WITH (
     ALLOW_PAGE_LOCKS = ON , 
     ALLOW_ROW_LOCKS = ON )
GO

CREATE TABLE Movie 
    (
     Id INTEGER NOT NULL , 
     Name VARCHAR (100) NOT NULL , 
     Description VARCHAR (MAX) NOT NULL , 
     Background VARCHAR (100) NOT NULL 
    )
GO

ALTER TABLE Movie ADD CONSTRAINT movie_PK PRIMARY KEY CLUSTERED (Id)
     WITH (
     ALLOW_PAGE_LOCKS = ON , 
     ALLOW_ROW_LOCKS = ON )
GO

CREATE TABLE MovieActor 
    (
     IdMovie INTEGER NOT NULL , 
     IdActor INTEGER NOT NULL 
    )
GO

CREATE TABLE MovieGenre 
    (
     IdMovie INTEGER NOT NULL , 
     IdGenre INTEGER NOT NULL 
    )
GO

ALTER TABLE MovieActor 
    ADD CONSTRAINT MovieActor_actor_FK FOREIGN KEY 
    ( 
     IdActor
    ) 
    REFERENCES Actor 
    ( 
     Id 
    ) 
    ON DELETE NO ACTION 
    ON UPDATE NO ACTION 
GO

ALTER TABLE MovieActor 
    ADD CONSTRAINT MovieActor_movie_FK FOREIGN KEY 
    ( 
     IdMovie
    ) 
    REFERENCES Movie 
    ( 
     Id 
    ) 
    ON DELETE NO ACTION 
    ON UPDATE NO ACTION 
GO

ALTER TABLE MovieGenre 
    ADD CONSTRAINT MovieGenre_Genre_FK FOREIGN KEY 
    ( 
     IdGenre
    ) 
    REFERENCES Genre 
    ( 
     Id 
    ) 
    ON DELETE NO ACTION 
    ON UPDATE NO ACTION 
GO

ALTER TABLE MovieGenre 
    ADD CONSTRAINT MovieGenre_movie_FK FOREIGN KEY 
    ( 
     IdMovie
    ) 
    REFERENCES Movie 
    ( 
     Id 
    ) 
    ON DELETE NO ACTION 
    ON UPDATE NO ACTION 
GO



-- Informe de Resumen de Oracle SQL Developer Data Modeler: 
-- 
-- CREATE TABLE                             5
-- CREATE INDEX                             0
-- ALTER TABLE                              7
-- CREATE VIEW                              0
-- ALTER VIEW                               0
-- CREATE PACKAGE                           0
-- CREATE PACKAGE BODY                      0
-- CREATE PROCEDURE                         0
-- CREATE FUNCTION                          0
-- CREATE TRIGGER                           0
-- ALTER TRIGGER                            0
-- CREATE DATABASE                          0
-- CREATE DEFAULT                           0
-- CREATE INDEX ON VIEW                     0
-- CREATE ROLLBACK SEGMENT                  0
-- CREATE ROLE                              0
-- CREATE RULE                              0
-- CREATE SCHEMA                            0
-- CREATE SEQUENCE                          0
-- CREATE PARTITION FUNCTION                0
-- CREATE PARTITION SCHEME                  0
-- 
-- DROP DATABASE                            0
-- 
-- ERRORS                                   0
-- WARNINGS                                 0

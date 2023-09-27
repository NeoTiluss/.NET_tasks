-- Create Teacher table


CREATE TABLE Teacher (
    TeacherID SERIAL PRIMARY KEY,
    FirstName VARCHAR(255),
    LastName VARCHAR(255),
    Gender CHAR(1),
    Subject VARCHAR(255)
);

-- Create Pupil table


CREATE TABLE Pupil (
    PupilID SERIAL PRIMARY KEY,
    FirstName VARCHAR(255),
    LastName VARCHAR(255),
    Gender CHAR(1),
    Class VARCHAR(255)
);

-- Create TeacherPupil junction table


CREATE TABLE TeacherPupil (
    TeacherPupilID SERIAL PRIMARY KEY,
    TeacherID INT REFERENCES Teacher(TeacherID),
    PupilID INT REFERENCES Pupil(PupilID)
);

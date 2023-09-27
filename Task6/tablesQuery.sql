SELECT DISTINCT T.*
FROM Teacher AS T
JOIN TeacherPupil AS TP ON T.TeacherID = TP.TeacherID
JOIN Pupil AS P ON TP.PupilID = P.PupilID
WHERE P.FirstName = 'Giorgi';

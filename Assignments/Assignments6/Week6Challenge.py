def rotate(matrix):
    """
    modify matrix in-place.
    """
    row = len(matrix)
    col = len(matrix[0])
    # transpose
    for i in range(row):
        for j in range(i + 1, col):
            matrix[i][j], matrix[j][i] = matrix[j][i], matrix[i][j]
    print(matrix)
    #then reverse each row.
    for rows in matrix:
        rows[:] = rows[::-1]
    return matrix
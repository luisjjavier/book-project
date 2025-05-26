import React, { useState } from 'react';
import {
    Box,
    Button,
    Container,
    FormControl,
    InputLabel,
    MenuItem,
    Select,
    SelectChangeEvent,
    TextField,
    Typography,
    Table,
    TableBody,
    TableCell,
    TableContainer,
    TableHead,
    TableRow,
    Paper
} from '@mui/material';
import axios from 'axios';

interface Book {
    id: string;
    title: string;
    firstName: string;
    lastName: string;
    isbn: string;
    ownershipStatus: string;
    publisher?: string;
    type?: string;
    category?: string;
    availableCopies?: string;
}

const App: React.FC = () => {
    const [searchBy, setSearchBy] = useState<string>('');
    const [searchValue, setSearchValue] = useState<string>('');
    const [books, setBooks] = useState<Book[]>([]);

    const handleSearch = async () => {
        const params: any = { page: 1, pageSize: 10 };
        if (searchBy === 'author') params.author = searchValue;
        else if (searchBy === 'isbn') params.isbn = searchValue;
        else if (searchBy === 'status') params.status = searchValue;

        const res = await axios.get<{ data: Book[]; totalCount: number }>('api/books/search', { params });
        setBooks(res.data.data);
    };

    return (
        <Container>
            <Typography variant="h4" align="center" mt={4} mb={2}>Royal Library</Typography>

            <Box border={1} p={3} mb={4} borderRadius={2}>
                <FormControl fullWidth margin="normal">
                    <InputLabel id="search-by-label">Search By</InputLabel>
                    <Select
                        labelId="search-by-label"
                        value={searchBy}
                        label="Search By"
                        onChange={(e: SelectChangeEvent) => setSearchBy(e.target.value)}
                    >
                        <MenuItem value="">Select</MenuItem>
                        <MenuItem value="author">Author</MenuItem>
                        <MenuItem value="isbn">ISBN</MenuItem>
                        <MenuItem value="status">Ownership Status</MenuItem>
                    </Select>
                </FormControl>

                <TextField
                    fullWidth
                    margin="normal"
                    label="Search Value"
                    value={searchValue}
                    onChange={(e) => setSearchValue(e.target.value)}
                />

                <Box mt={2}>
                    <Button variant="outlined" fullWidth onClick={handleSearch}>Search</Button>
                </Box>
            </Box>

            <Box border={1} p={3} borderRadius={2}>
                <Typography variant="h6" mb={2}>Search Results:</Typography>
                <TableContainer component={Paper}>
                    <Table>
                        <TableHead>
                            <TableRow>
                                <TableCell>Book Title</TableCell>
                                <TableCell>Publisher</TableCell>
                                <TableCell>Authors</TableCell>
                                <TableCell>Type</TableCell>
                                <TableCell>ISBN</TableCell>
                                <TableCell>Category</TableCell>
                                <TableCell>Available Copies</TableCell>
                            </TableRow>
                        </TableHead>
                        <TableBody>
                            {books.map((book) => (
                                <TableRow key={book.id}>
                                    <TableCell>{book.title}</TableCell>
                                    <TableCell>{book.publisher ?? '-'}</TableCell>
                                    <TableCell>{`${book.firstName} ${book.lastName}`}</TableCell>
                                    <TableCell>{book.type ?? '-'}</TableCell>
                                    <TableCell>{book.isbn}</TableCell>
                                    <TableCell>{book.category ?? '-'}</TableCell>
                                    <TableCell>{book.availableCopies ?? '-'}</TableCell>
                                </TableRow>
                            ))}
                        </TableBody>
                    </Table>
                </TableContainer>
            </Box>
        </Container>
    );
};

export default App;

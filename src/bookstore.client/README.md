# BookStore.Client

A modern React application for browsing and managing books, designed to work seamlessly with the [BookStore.Server](../BookStore.Server) .NET 9 Web API.

## Features

- Search and filter books by author, ISBN, and ownership status
- Paginated book listings
- Responsive UI with React and modern CSS
- API integration with BookStore.Server
- TypeScript support (if applicable)
- Component-based architecture

## Project Structure

bookstore.client/ 
	??? public/                # Static assets 
	??? src/ 
	?   ??? api/               # API service calls
	?   ??? components/        # Reusable React components 
	?   ??? pages/             # Page-level components/views 
	?   ??? App.jsx/tsx        # Main app component 
	?   ??? index.jsx/tsx      # Entry point 
	?   ??? ...                # Other utilities, hooks, etc. 
	??? package.json           # Project metadata and dependencies 
	??? README.md              # Project documentation 
import axios from 'axios'
export const fetchNotes = async (filter) =>{
    try
    {
        var response = await axios.get('/notes',{
            params:{
                search: filter?.search,
                sortItem: filter?.sortItem,
                sortOrder: filter?.sortOrder
            }
        });
        return Array.isArray(response.data) ? response.data : [];
    } 
    catch(e)
    {
        console.error(e);
    }
}

export const createNote = async (note) =>{
    try
    {
        var response = await axios.post('/notes',note);
        return response.status;
    } 
    catch(e)
    {
        console.error(e);
    }
}

export const deleteNote = async (id) =>{
    try
    {
        var response = await axios.post('/notes/delete', {id});
        return response.status;
    } 
    catch(e)
    {
        console.error(e);
        console.error('Error response:', e.response);
    }
}
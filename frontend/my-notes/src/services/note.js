import axios from 'axios'
export const fetchNotes = async (filter) =>{
    try
    {
        let response = await axios.get('/notes',{
            params:{
                search: filter?.search,
                sortItem: filter?.sortItem,
                sortOrder: filter?.sortOrder
            }
        });
        console.log("Response data:", response.data);
        return Array.isArray(response.data) ? response.data : [];
    } 
    catch(e)
    {
        console.error(e);
        return [];
    }
}

export const createNote = async (note) =>{
    try
    {
        let response = await axios.post('/notes',note);
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
        let response = await axios.post('/notes/delete', {id});
        return response.status;
    } 
    catch(e)
    {
        console.error(e);
        console.error('Error response:', e.response);
    }
}
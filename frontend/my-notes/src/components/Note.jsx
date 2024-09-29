import { Button, Card, CardBody, CardFooter, CardHeader, Divider, Flex, Heading, Text } from '@chakra-ui/react';
import moment from 'moment'

export default function Note({title, description, createdAt, onDelete, id}){
  const onSubmit = (e) => {
    console.log('submit')
    e.preventDefault();
    onDelete(id);
  }
    return(
        <Card variant={'filled'} onSubmit={onSubmit}>
              <CardHeader>
              <Flex justify="space-between" align="center">
                <Heading size={'md'}>{title}</Heading>
                <Button type='submit' colorScheme='red' size={'xs'}>Удалить</Button>
                </Flex>
              </CardHeader>
              <Divider borderColor={"gray"} />
              <CardBody>
                <Text>{description}</Text>
              </CardBody>
              <Divider borderColor={"gray"} />
              <CardFooter>{moment(createdAt).format('DD MMMM YYYY HH:mm:ss')}</CardFooter>
            </Card>
    );
}
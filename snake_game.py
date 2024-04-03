import pygame
import random
import fernet
import os

KEY_FILE = 'key.key'

if not os.path.exists(KEY_FILE):
    key = fernet.Fernet.generate_key()
    with open(KEY_FILE, 'wb') as key_file:
        key_file.write(key)
else:
    with open(KEY_FILE, 'rb') as key_file:
        key = key_file.read()

cipher_suite = fernet.Fernet(key)

pygame.init()
screen_width = 1280
screen_height = 720
screen = pygame.display.set_mode((screen_width, screen_height))
surface = pygame.Surface((screen_width, screen_height), pygame.SRCALPHA)
pygame.display.set_caption('Snake Game')
pygame_icon = pygame.image.load('./img/snake.png')
pygame.display.set_icon(pygame_icon)
clock = pygame.time.Clock()
font = pygame.font.SysFont('monospace-bold', 16)

running = True
game_paused = False
game_over = False


# Função para salvar o high score em um arquivo
def save_high_score(score):
    encrypted_score = cipher_suite.encrypt(str(score).encode())
    with open('high_score.txt', 'wb') as file:
        file.write(encrypted_score)


# Função para carregar o high score de um arquivo
def load_high_score():
    try:
        with open('high_score.txt', 'rb') as file:
            encrypted_score = file.read()
            decrypted_score = cipher_suite.decrypt(encrypted_score)
            return int(decrypted_score.decode())
    except FileNotFoundError:
        return 0


# Verificar e salvar o high score quando o jogo termina
def check_and_save_high_score(score):
    high_score = load_high_score()
    if score > high_score:
        save_high_score(score)


def generate_initial_position():
    x_position = random.randint(0, screen_width - pixel_width)
    y_position = random.randint(0, screen_height - pixel_height)
    return x_position, y_position


def generate_initial_direction():
    return random.choice([UP, DOWN, LEFT, RIGHT])


def draw_pause():
    surface.fill('purple')
    text = font.render("Paused", True, (255, 255, 255))
    text_rect = text.get_rect(center=(screen_width // 2, screen_height // 2))
    surface.blit(text, text_rect)


# Playground
pixel_width = 10
pixel_height = 10

# Snake Initial Size
initial_snake_size = 10

# Growth per food
growth_rate = 10

# Snake
snake = []
for _ in range(initial_snake_size):
    segment = pygame.Rect(0, 0, pixel_width, pixel_height)
    segment.center = generate_initial_position()
    snake.append(segment)

# Food
food_pixel = pygame.rect.Rect(0, 0, pixel_width * 0.8, pixel_height * 0.8)
food_pixel.center = generate_initial_position()

# Points
score = 0
high_score = load_high_score()


UP = 0
DOWN = 1
LEFT = 2
RIGHT = 3

direction = generate_initial_direction()
velocity = 2

change_delay = 0
change_delay_time = 6

# Game Loop
while running:
    for event in pygame.event.get():
        if event.type == pygame.QUIT:
            running = False
        elif event.type == pygame.KEYDOWN:
            if change_delay == 0:
                if event.key == pygame.K_w and direction != DOWN:
                    direction = UP
                    change_delay = change_delay_time
                elif event.key == pygame.K_s and direction != UP:
                    direction = DOWN
                    change_delay = change_delay_time
                elif event.key == pygame.K_a and direction != RIGHT:
                    direction = LEFT
                    change_delay = change_delay_time
                elif event.key == pygame.K_d and direction != LEFT:
                    direction = RIGHT
                    change_delay = change_delay_time
                if event.key == pygame.K_ESCAPE:
                    print(game_paused)
                    game_paused = not game_paused

    if game_paused:
        draw_pause()
        screen.blit(surface, (0, 0))

    if change_delay > 0:
        change_delay -= 1

    score_label = font.render('Score: ' + str(score), True, (255, 255, 255))
    high_score_label = font.render('High Score: ' + str(high_score), True, (255, 255, 255))

    if snake[0].colliderect(food_pixel):
        score += 1
        if score > high_score:
            high_score = score
        if score % 10 == 0:
            velocity += 1
            print(velocity)
        food_pixel.center = generate_initial_position()
        for _ in range(growth_rate):
            new_tail = pygame.Rect(snake[-1])
            snake.append(new_tail)

    for segment in snake[9:]:
        if snake[0].colliderect(segment):
            game_over = True
            running = False
            break

    if game_over:
        check_and_save_high_score(score)
        running = False
        break

    if not game_paused:
        for i in range(len(snake) - 1, 0, -1):
            snake[i].x = snake[i - 1].x
            snake[i].y = snake[i - 1].y

        # Snake Movement
        if direction == UP:
            snake[0].y -= velocity
            if snake[0].y < 0:
                snake[0].y = screen_height - pixel_height
            pass
        elif direction == DOWN:
            snake[0].y += velocity
            if snake[0].y >= screen_height:
                snake[0].y = 0
            pass
        elif direction == LEFT:
            snake[0].x -= velocity
            if snake[0].x < 0:
                snake[0].x = screen_width - pixel_width
            pass
        elif direction == RIGHT:
            snake[0].x += velocity
            if snake[0].x >= screen_width:
                snake[0].x = 0
            pass

    screen.fill('black')
    pygame.draw.rect(screen, 'purple', snake[0])
    for segment in snake[1:]:
        pygame.draw.rect(screen, 'purple', segment)
    pygame.draw.rect(screen, 'red', food_pixel)
    screen.blit(score_label, (2, 2))
    screen.blit(high_score_label, (2, 16))
    pygame.display.flip()
    clock.tick(60)

pygame.quit()
